import 'reflect-metadata';
import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import type { IProblem } from '@/data/abstractions/IProblem';
import type { IProblemApi } from '@/services/api/problem/problemApi';
import { IImplementedProblemBaseFields } from '@/data/abstractions/IImplementedProblem';
import { ISolution } from '@/data/abstractions/ISolution';
import { ITestCase } from '@/data/abstractions/ITestCase';

export interface IProblemSolvingVM {
  code: string;
  problem: IProblem | undefined;
  setCode: (code: string | undefined) => void;
  testcases: ITestCase[];
  output: string;
  setProblemId: (problemId: number) => void;
  isOutputLoading: boolean;
  testSolutionWithSpecifiedTestcases: () => void;
  submitSolution: () => void;

  formatJsonString(json: string): string;
}

@injectable()
class ProblemSolvingVM implements IProblemSolvingVM {
  private readonly authApi: IAuthApi;
  private readonly problemApi: IProblemApi;

  @observable
  public code: string = 'Loading...';

  @observable
  public isOutputLoading: boolean = false;

  @observable
  public problemId: number = -1;

  @observable
  public problem: IProblem | undefined = undefined;

  @observable
  public implementedProblems: IImplementedProblemBaseFields[] = [];

  @observable
  public solution: ISolution | undefined = undefined;

  @observable
  public testcases: ITestCase[] = [];

  @observable
  private lastUpdateTime: number | null = null;

  @observable
  public output: string = 'Output: ^-^';

  private readonly updateInterval = 5000;

  constructor(
    @inject(ServiceSymbols.ProblemApi) problemApi: IProblemApi,
    @inject(ServiceSymbols.AuthApi) authApi: IAuthApi
  ) {
    this.authApi = authApi;
    this.problemApi = problemApi;

    this.checkAuth();

    makeObservable(this);
  }

  @action
  public setCode = (code: string | undefined) => {
    if (code === undefined) {
      return;
    }

    this.code = code;

    const now = Date.now();
    if (!this.lastUpdateTime || now - this.lastUpdateTime >= this.updateInterval) {
      this.lastUpdateTime = now;
      this.updateSolutionCode();
    }
  };

  @action.bound
  public updateSolutionCode = flow(function* (this: ProblemSolvingVM) {
    try {
      if (this.solution) {
        yield this.problemApi.updateSolution(this.solution.id, this.code);
      }
    } catch (e) {
      console.error(e);
    }
  });

  @action
  public setProblemId = (problemId: number) => {
    this.problemId = problemId;
    this.getProblemAndSolution();
  };

  @action.bound
  public getProblemAndSolution = flow(function* (this: ProblemSolvingVM) {
    try {
      this.problem = yield this.problemApi.getProblemById(this.problemId);

      this.implementedProblems = yield this.problemApi.getImplementedProblemsByProblemId(this.problemId);

      const solutions: ISolution[] = yield this.problemApi.getSolutionsByImplementedProblemId(this.implementedProblems[0].id);
      if (!solutions || solutions.length <= 0) {
        const solutionId = yield this.problemApi.createByImplementedProblem(this.implementedProblems[0].id);
        this.solution = yield this.problemApi.getSolutionById(solutionId);
      } else {
        this.solution = solutions.sort((a,b) => a.id - b.id)[solutions.length-1];
      }

      this.code = this.solution!.code;

      this.testcases = yield this.problemApi.getTestCasesByProblemId(this.problemId);
    } catch (e) {
      this.problem = undefined;
    }
  });

  @action.bound
  public checkAuth = flow(function* (this: ProblemSolvingVM) {
    try {
      const user = yield this.authApi.getCurrentUser();
      if (!user) {
        window.location.href = '/sign-in';
      }
    } catch (e) {
      window.location.href = '/sign-in';
    }
  });

  private generateSummary(result: SolutionResult): string {
    const { isPassed, runTestCaseResults } = result;

    let summary = `Test ${isPassed ? 'passed' : 'failed'}.\n\n`;

    runTestCaseResults.forEach((testCase, index) => {
      const {
        testCaseData: { input, output },
        usedTime,
        usedMemory,
        errorMessage,
        incorrectAnswer
      } = testCase;

      summary += `Test Case #${index + 1} ${(incorrectAnswer || errorMessage) ? 'failed' : 'passed'}:\n`;
      summary += `\tInput: ${input}\n`;
      summary += `\tExpected Output: ${output}\n`;
      if (incorrectAnswer) {
        summary += `\tOutput: ${incorrectAnswer}\n`;
      }
      if (usedTime) {
        summary += `\tUsed Time: ${usedTime} ms\n`;
      }
      if (usedMemory) {
        summary += `\tUsed Memory: ${usedMemory} KB\n`;
      }
      if (errorMessage) {
        summary += `\tError: ${errorMessage}\n`;
      }
      summary += '\n';
    });

    return summary.trim();
  }

  private generateDetailedSummary(summary: SolutionSummary): string {
    const {
      isPassed,
      totalUsedTime,
      totalUsedMemory,
      testCaseResultWithError,
      testCaseResultWithWrongAnswer
    } = summary;

    let result = `Test ${isPassed ? 'passed' : 'failed'}.\n`;
    result += `Total Used Time: ${totalUsedTime} ms\n`;
    result += `Total Used Memory: ${totalUsedMemory} KB\n\n`;

    if (testCaseResultWithError) {
      const { testCaseData, usedTime, usedMemory, errorMessage } =
        testCaseResultWithError;
      result += `Test Case with Error:\n`;
      result += `Input: ${testCaseData.input}\n`;
      result += `Expected Output: ${testCaseData.output}\n`;
      result += `Used Time: ${usedTime} ms\n`;
      result += `Used Memory: ${usedMemory} KB\n`;
      result += `Error: ${errorMessage}\n\n`;
    }

    if (testCaseResultWithWrongAnswer) {
      const { testCaseData, usedTime, usedMemory, incorrectAnswer } =
        testCaseResultWithWrongAnswer;
      result += `Test Case with Wrong Answer:\n`;
      result += `Input: ${testCaseData.input}\n`;
      result += `Expected Output: ${testCaseData.output}\n`;
      result += `Used Time: ${usedTime} ms\n`;
      result += `Used Memory: ${usedMemory} KB\n`;
      result += `Incorrect Answer: ${incorrectAnswer}\n`;
    }

    return result.trim();
  }
  
  @action.bound
  public testSolutionWithSpecifiedTestcases = flow(function* (this: ProblemSolvingVM) {
    try {
      if (!this.solution)
        return;

      this.isOutputLoading = true;
      this.output = 'Loading...';
      
      yield this.updateSolutionCode();

      const response = yield this.problemApi.testSolutionWithSpecifiedTestcases(this.solution.id, this.testcases);

      this.output = this.generateSummary(response);
    } catch (e) {
    } finally {
      this.isOutputLoading = false;
    }
  });

  @action.bound
  public submitSolution = flow(function* (this: ProblemSolvingVM) {

    try {
      if (!this.solution) {
        return;
      }

      this.isOutputLoading = true;
      this.output = 'Loading...';

      const newSolutionId = yield this.problemApi.createSolutionCopy(this.solution.id);
      this.solution = yield this.problemApi.getSolutionById(newSolutionId);

      yield this.updateSolutionCode();

      if (!this.solution) {
        throw new Error()
      }

      const response = yield this.problemApi.submitSolution(this.solution.id);

      this.output = this.generateDetailedSummary(response);
    } catch (e) {
      this.output = 'Ошибка отправки решения на проверку, попробуйте снова';
    } finally {
      this.isOutputLoading = false;
    }
  });

  public formatJsonString = (json: string): string => {
    try {
      const parsedObject = JSON.parse(json);

      const formatValue = (value: any): string => {
        if (Array.isArray(value)) {
          return `[${value.map(formatValue).join(', ')}]`;
        } else if (typeof value === 'object' && value !== null) {
          return `{ ${Object.entries(value)
            .map(([key, val]) => `${key}: ${formatValue(val)}`)
            .join(', ')} }`;
        }
        return String(value);
      };

      return Object.entries(parsedObject)
        .map(([key, value]) => `${key} = ${formatValue(value)}`)
        .join(', ');
    } catch (error) {
      return 'Invalid JSON string';
    }
  };
}

export default ProblemSolvingVM;
