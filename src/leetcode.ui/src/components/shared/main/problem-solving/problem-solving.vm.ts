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
  setProblemId: (problemId: number) => void;
}

@injectable()
class ProblemSolvingVM implements IProblemSolvingVM {
  private readonly authApi: IAuthApi;
  private readonly problemApi: IProblemApi;


  @observable
  public code: string = 'Loading...';

  @observable
  public problemId: number = -1;

  @observable
  public problem: IProblem | undefined = undefined

  @observable
  public implementedProblems: IImplementedProblemBaseFields[] = []

  @observable
  public solution: ISolution | undefined = undefined

  @observable
  public testcases: ITestCase[] = []

  @observable
  private lastUpdateTime: number | null = null;
  
  private readonly updateInterval = 5000;

  constructor(
    @inject(ServiceSymbols.ProblemApi) problemApi: IProblemApi,
    @inject(ServiceSymbols.AuthApi) authApi: IAuthApi
  ) {
    this.authApi = authApi;
    this.problemApi = problemApi;
    
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
      console.error("Failed to update solution code:", e);
    }
  });
  
  @action
  public setProblemId = (problemId: number) => {
    this.problemId = problemId;
    this.getProblemAndSolution()
  };

  @action.bound
  public getProblemAndSolution = flow(function* (this: ProblemSolvingVM) {
    try {
      this.problem = yield this.problemApi.getProblemById(this.problemId)
      
      this.implementedProblems = yield this.problemApi.getImplementedProblemsByProblemId(this.problemId);
      
      const solutions = yield this.problemApi.getSolutionsByImplementedProblemId(this.implementedProblems[0].id)
      if (!solutions || solutions.length <= 0) {
        const solutionId = yield this.problemApi.createByImplementedProblem(this.implementedProblems[0].id)
        this.solution = yield this.problemApi.getSolutionById(solutionId)
      } else {
        this.solution = solutions[0]
      }
      
      this.code = this.solution!.code
      
      this.testcases = yield this.problemApi.getTestCasesByProblemId(this.problemId)
    } catch (e) {
      this.problem = undefined;
    }
  });
}

export default ProblemSolvingVM;
