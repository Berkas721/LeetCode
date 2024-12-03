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
  
  public static readonly Problem = class {
    public static readonly base = (): string =>
      `${Endpoints.suffix}/${Endpoints.v1}/problem`;

    // @method get
    public static readonly getProblems = (): string =>
      `${Endpoints.Problem.base()}`;

    // @method get
    public static readonly getProblemById = (problemId: number): string =>
      `${Endpoints.Problem.base()}/${problemId}`;

    // @method get
    public static readonly getTestCases = (problemId: number, count: number = 2): string =>
      `${Endpoints.Problem.base()}/${problemId}/testcases/${count}`;

    // @method get
    public static readonly getImplementedProblems = (problemId: number): string =>
      `${Endpoints.Problem.base()}/${problemId}/implemented-problems`;
  }

  public static readonly ImplementedProblem = class {
    public static readonly base = (): string =>
      `${Endpoints.suffix}/${Endpoints.v1}/implemented-problem`;

    // @method get
    public static readonly getImplementedProblemById = (id: number): string =>
      `${Endpoints.ImplementedProblem.base()}/${id}`;

    // @method get
    public static readonly getSolutionsByImplementedProblemId = (implementedProblemId: string): string =>
      `${Endpoints.ImplementedProblem.base()}/${implementedProblemId}/solutions`;
  }

  public static readonly Solution = class {
    public static readonly base = (): string =>
      `${Endpoints.suffix}/${Endpoints.v1}/solutions`;

    // @method post
    public static readonly createByImplementedProblem = (implementedProblemId: string): string =>
      `${Endpoints.Solution.base()}/create-by-implemented-problem/${implementedProblemId}`;

    // @method post
    public static readonly createSolutionCopy = (solutionId: number): string =>
      `${Endpoints.Solution.base()}/${solutionId}/create-copy`;


    // @method get
    public static readonly getSolutionById = (solutionId: number): string =>
      `${Endpoints.Solution.base()}/${solutionId}`;

    // @method put
    public static readonly testSolutionWithSpecifiedTestcases = (solutionId: number): string =>
      `${Endpoints.Solution.base()}/${solutionId}/test-with-specified-testcases`;

    // @method put
    public static readonly submitSolution = (solutionId: number): string =>
      `${Endpoints.Solution.base()}/${solutionId}/submit`;

    // @method put
    public static readonly updateSolution = (solutionId: number): string =>
      `${Endpoints.Solution.base()}/${solutionId}/update`;
  }
}
