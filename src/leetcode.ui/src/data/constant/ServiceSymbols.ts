const ServiceSymbols = {
  AxiosInstance: Symbol.for('AxiosInstance'),
  AuthApi: Symbol.for('AuthApi'),
  ProblemApi: Symbol.for('ProblemApi'),
  
  ISignInFormVM: Symbol.for('ISignInFormVM'),
  ISignUpFormVM: Symbol.for('ISignUpFormVM'),
  
  IHeaderVM: Symbol.for('IHeaderVM'),
  IProblemsLibVM: Symbol.for('IProblemsLibVM'),
  IProblemSolvingVM: Symbol.for('IProblemSolvingVM'),
};

export default ServiceSymbols;
