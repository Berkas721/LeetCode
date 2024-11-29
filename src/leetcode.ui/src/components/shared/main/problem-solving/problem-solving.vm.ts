import 'reflect-metadata';
import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IUser } from '@/data/abstractions/IUser';
import type { IProblem } from '@/data/abstractions/IProblem';

export interface IProblemSolvingVM {
  code: string;
  problem: IProblem;
  setCode: (code: string | undefined) => void;
  setProblemId: (problemId: number) => void;
}

@injectable()
class ProblemSolvingVM implements IProblemSolvingVM {
  private readonly authApi: IAuthApi;

  @observable
  public user: IUser | null = null;

  @observable
  public code: string = `public class Solution\r\n{\r\n    public static int GetSumma(int a, int b)\r\n    {\r\n        throw NotImplementedException();\r\n    }\r\n}`;

  @observable
  public problemId: number = -1;

  @observable
  public problem: IProblem = {
    'id': 2,
    'name': 'Определение простого числа',
    'description': 'Напишите функцию, которая проверяет, является ли число простым.',
    'difficulty': 1,
    'status': 1,
    'creatorId': 'a4c8f690-b7e1-412f-9f76-e2fbb582f89e',
    'createdAt': '2024-11-15T10:15:00.000000Z',
    'updaterId': 'a4c8f690-b7e1-412f-9f76-e2fbb582f89e',
    'updatedAt': '2024-11-16T14:30:00.000000Z',
    'openerId': 'a4c8f690-b7e1-412f-9f76-e2fbb582f89e',
    'openedAt': '2024-11-16T14:45:00.000000Z'
  };

  constructor(
    @inject(ServiceSymbols.AuthApi) authApi: IAuthApi
  ) {
    this.authApi = authApi;
    this.getCurrentUser();

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
  };

  @action.bound
  public getCurrentUser = flow(function* (this: ProblemSolvingVM) {
    try {
      this.user = yield this.authApi.getCurrentUser();
    } catch (e) {
      this.user = null;
    }
  });
}

export default ProblemSolvingVM;
