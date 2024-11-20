import React from 'react';
import { Container } from 'inversify';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import SignInFormVM, { ISignInFormVM } from '@/components/shared/auth/sign-in/sign-in-form.vm';
import SignUpFormVM, { ISignUpFormVM } from '@/components/shared/auth/sign-up/sign-up-form.vm';


export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<ISignInFormVM>(ServiceSymbols.ISignInFormVM).to(SignInFormVM);
  container.bind<ISignUpFormVM>(ServiceSymbols.ISignUpFormVM).to(SignUpFormVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;
