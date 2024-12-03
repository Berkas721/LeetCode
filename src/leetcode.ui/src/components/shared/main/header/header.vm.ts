import 'reflect-metadata';
import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IUser } from '@/data/abstractions/IUser';

export interface IHeaderVM {
  user: IUser | null;
  signOut: () => void;
}

@injectable()
class HeaderVM implements IHeaderVM {

  private readonly authApi: IAuthApi;

  @observable
  public user: IUser | null = null;

  constructor(
    @inject(ServiceSymbols.AuthApi) authApi: IAuthApi,
  ) {
    this.authApi = authApi;
    this.getCurrentUser();

    makeObservable(this);
  }

  @action.bound
  public getCurrentUser = flow(function* (this: HeaderVM) {
    try {
      this.user = yield this.authApi.getCurrentUser();
    } catch (e) {
      this.user = null;
    }
  });

  @action.bound
  public signOut = flow(function* (this: HeaderVM) {
    console.log('asdsad');
    try {
      yield this.authApi.signOut();
      window.location.href = '/sign-in';
    } catch (e) {
    } finally {
    }
  });
}

export default HeaderVM;
