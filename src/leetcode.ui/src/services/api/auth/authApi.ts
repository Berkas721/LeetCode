import ApiClientBase from '@/services/api/api.base';
import Endpoints from '@/services/api/endpoints';
import { ISignInPayload } from '@/data/abstractions/ISignInPayload';
import { ISignUpPayload } from '@/data/abstractions/ISignUpPayload';
import { IUser } from '@/data/abstractions/IUser';

export interface IAuthApi {
  signIn(payload: ISignInPayload): Promise<boolean>;
  signUp(payload: ISignUpPayload): Promise<boolean>;
  signOut(): Promise<boolean>;
  getCurrentUser(): Promise<IUser>;
}

export class AuthApi
  extends ApiClientBase
  implements IAuthApi {

  public readonly signIn = async (
    { password, username }: ISignInPayload
  ): Promise<boolean> => {
    const url = Endpoints.Auth.signIn();
    const response = await this.asyncRunner(
      () => this.api.put(url, { username, password })
    );
    return this.isSuccessfulStatusCode(response.status);
  };

  public readonly signUp = async (payload: ISignUpPayload): Promise<boolean> => {
    const url = Endpoints.Auth.signUp();
    const response = await this.asyncRunner(
      () => this.api.post(url, payload)
    )
    return this.isSuccessfulStatusCode(response.status);
  };

  public readonly signOut = async (): Promise<boolean> => {
    const url = Endpoints.Auth.signOut();
    const response = await this.asyncRunner(
      () => this.api.put(url)
    )
    return this.isSuccessfulStatusCode(response.status);
  };

  public readonly getCurrentUser = async (): Promise<IUser> => {
    const url = Endpoints.Auth.getCurrentUser();
    const response = await this.asyncRunner(
      () => this.api.get(url)
    )
    return response.data as IUser;
  };
}
