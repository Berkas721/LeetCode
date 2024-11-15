import React from 'react';
import { Container } from 'inversify';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import SignInFormVM, { ISignInFormVM } from '@/components/shared/auth/sign-in/sign-in-form.vm';


export const createDependencyContainer = (): Container => {
  const container = new Container();

  container.bind<ISignInFormVM>(ServiceSymbols.ISignInFormVM).to(SignInFormVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;
