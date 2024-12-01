import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';
import { ITestCase } from '@/data/abstractions/ITestCase';
import { IProblem } from '@/data/abstractions/IProblem';
import { IImplementedProblem } from '@/data/abstractions/IImplementedProblem';
import { ISolution } from '@/data/abstractions/ISolution';

export interface IProblemApi {
  getProblems: () => void;
  getProblemById: (problemId: number) => void;
  getImplementedProblemById: (implementedProblemId: number) => void;
  getSolutionById: (solutionId: number) => void;
  createByImplementedProblem: (implementedProblemId: number) => void;
  testSolutionWithSpecifiedTestcases: (solutionId: number, payload: ITestCase[]) => void;
  submitSolution: (solutionId: number) => void;
  updateSolution: (solutionId: number, payload: string) => void;
}

export class ProblemApi
  extends ApiClientBase
  implements IProblemApi {

  public readonly getProblems = async () => {
    const url = Endpoints.Problem.getProblems();
    const response = await this.asyncRunner(
      () => this.api.get(url)
    );

    return response.data as IProblem[];
  };

  public readonly getProblemById = async (problemId: number) => {
    const url = Endpoints.Problem.getProblemById(problemId);
    const response = await this.asyncRunner(
      () => this.api.get(url)
    );

    return response.data as IProblem;
  };

  public readonly getImplementedProblemById = async (implementedProblemId: number) => {
    const url = Endpoints.ImplementedProblem.getImplementedProblemById(implementedProblemId);
    const response = await this.asyncRunner(
      () => this.api.get(url)
    );
    return response.data as IImplementedProblem;
  };

  public readonly getSolutionById = async (solutionId: number) => {
    const url = Endpoints.Solution.getSolutionById(solutionId);
    const response = await this.asyncRunner(
      () => this.api.get(url)
    );
    return response.data as ISolution;
  };

  public readonly createByImplementedProblem = async (implementedProblemId: number) => {
    const url = Endpoints.Solution.createByImplementedProblem(implementedProblemId);
    const response = await this.asyncRunner(
      () => this.api.post(url)
    );
    return response.data as number;
  };

  public readonly testSolutionWithSpecifiedTestcases = async (solutionId: number, payload: ITestCase[]) => {
    const url = Endpoints.Solution.testSolutionWithSpecifiedTestcases(solutionId);
    const response = await this.asyncRunner(
      () => this.api.put(url, payload)
    );
    return response.data;
  };

  public readonly submitSolution = async (solutionId: number) => {
    const url = Endpoints.Solution.submitSolution(solutionId);
    const response = await this.asyncRunner(
      () => this.api.put(url)
    );
    return response.data;
  };

  public readonly updateSolution = async (solutionId: number, payload: string) => {
    const url = Endpoints.Solution.updateSolution(solutionId);
    const response = await this.asyncRunner(
      () => this.api.put(url, payload)
    );
    return response.data;
  };
}
