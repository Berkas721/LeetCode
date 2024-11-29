const ServiceSymbols = {
  AxiosInstance: Symbol.for('AxiosInstance'),
  AuthApi: Symbol.for('AuthApi'),
  
  ISignInFormVM: Symbol.for('ISignInFormVM'),
  ISignUpFormVM: Symbol.for('ISignUpFormVM'),
  
  IHeaderVM: Symbol.for('IHeaderVM'),
  IProblemsLibVM: Symbol.for('IProblemsLibVM'),
};

export default ServiceSymbols;
