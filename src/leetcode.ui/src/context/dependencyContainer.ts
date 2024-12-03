import React from 'react';
import { Container } from 'inversify';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import axios, { AxiosInstance } from 'axios';
import { AuthApi, IAuthApi } from '@/services/api/auth/authApi';
import SignInFormVM, { ISignInFormVM } from '@/components/shared/auth/sign-in/sign-in-form.vm';
import SignUpFormVM, { ISignUpFormVM } from '@/components/shared/auth/sign-up/sign-up-form.vm';
import HeaderVM, { IHeaderVM } from '@/components/shared/main/header/header.vm';
import ProblemsLibVM, { IProblemsLibVM } from '@/components/shared/main/home-page/problems-lib/problems-lib.vm';
import ProblemSolvingVM, { IProblemSolvingVM } from '@/components/shared/main/problem-solving/problem-solving.vm';
import { IProblemApi, ProblemApi } from '@/services/api/problem/problemApi';


export const createDependencyContainer = (): Container => {
  const container = new Container();

  container
    .bind<AxiosInstance>(ServiceSymbols.AxiosInstance)
    .toFactory(() => axios.create());
  container.bind<IAuthApi>(ServiceSymbols.AuthApi).to(AuthApi).inSingletonScope();
  container.bind<IProblemApi>(ServiceSymbols.ProblemApi).to(ProblemApi).inSingletonScope();

  container.bind<ISignInFormVM>(ServiceSymbols.ISignInFormVM).to(SignInFormVM);
  container.bind<ISignUpFormVM>(ServiceSymbols.ISignUpFormVM).to(SignUpFormVM);

  container.bind<IHeaderVM>(ServiceSymbols.IHeaderVM).to(HeaderVM).inSingletonScope();
  container.bind<IProblemsLibVM>(ServiceSymbols.IProblemsLibVM).to(ProblemsLibVM);
  container.bind<IProblemSolvingVM>(ServiceSymbols.IProblemSolvingVM).to(ProblemSolvingVM);

  return container;
};

const DependencyContainer = React.createContext<Container>({} as Container);

export default DependencyContainer;
