export default class Endpoints {
  public static baseApiUrl: string

  public static readonly suffix = 'api';

  public static readonly v1 = 'v1';

  public static readonly Auth = class {
    public static readonly base = (): string =>
      `${Endpoints.suffix}/${Endpoints.v1}/auth`;

    // @method put
    public static readonly signIn = (): string =>
      `${Endpoints.Auth.base()}/signin`;

    // @method post
    public static readonly signUp = (): string =>
      `${Endpoints.Auth.base()}/signup`;

    // @method put
    public static readonly signOut = (): string =>
      `${Endpoints.Auth.base()}/signout`;

    // @method get
    public static readonly getCurrentUser = (): string =>
      `${Endpoints.Auth.base()}/current-user`;
  }
}
