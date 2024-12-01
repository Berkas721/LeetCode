import 'reflect-metadata';
import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IProblem } from '@/data/abstractions/IProblem';
import type { IProblemApi } from '@/services/api/problem/problemApi';

export interface IProblemsLibVM {
  isLoading: boolean;
  problems: IProblem[];
  getAllProblems: () => void;
}

@injectable()
class ProblemsLibVM implements IProblemsLibVM {

  private readonly authApi: IAuthApi;
  private readonly problemApi: IProblemApi;

  @observable
  public isLoading: boolean = false;

  @observable
  public problems: IProblem[] = [];

  constructor(
    @inject(ServiceSymbols.AuthApi) authApi: IAuthApi,
    @inject(ServiceSymbols.ProblemApi) problemApi: IProblemApi
  ) {
    this.authApi = authApi;
    this.problemApi = problemApi;
    this.getAllProblems();

    makeObservable(this);
  }

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };

  @action.bound
  public getAllProblems = flow(function* (this: ProblemsLibVM) {
    try {
      this.setIsLoading(true);
      this.problems = yield this.problemApi.getProblems()
    } catch (e) {
    } finally {
      this.setIsLoading(false);
    }
  });
}

export default ProblemsLibVM;
