import 'reflect-metadata';
import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IUser } from '@/data/abstractions/IUser';
import type { IProblem } from '@/data/abstractions/IProblem';
import type { IProblemApi } from '@/services/api/problem/problemApi';
import { IProblemFull } from '@/data/abstractions/IProblemFull';

export interface IProblemSolvingVM {
  code: string;
  problemFull: IProblemFull | undefined;
  setCode: (code: string | undefined) => void;
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
  public problemFull: IProblemFull | undefined = undefined

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
  };

  @action
  public setProblemId = (problemId: number) => {
    this.problemId = problemId;
    this.getFullProblem()
  };

  // @action.bound
  // public createSolution = flow(function* (this: ProblemSolvingVM) {
  //   try {
  //     this.problem = yield this.problemApi.getProblemById(this.problemId)
  //   } catch (e) {
  //     this.problem = null;
  //   }
  // });

  @action.bound
  public getFullProblem = flow(function* (this: ProblemSolvingVM) {
    try {
      const problems: IProblemFull[] = yield this.problemApi.getProblems();
      this.problemFull = problems.find(x => String(x.id) === String(this.problemId))
      
      
      
    } catch (e) {
      this.problemFull = undefined;
    }
  });
}

export default ProblemSolvingVM;
