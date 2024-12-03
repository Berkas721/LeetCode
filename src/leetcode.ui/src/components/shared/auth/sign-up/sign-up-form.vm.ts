import 'reflect-metadata';
import { inject, injectable } from 'inversify';
import { action, flow, makeObservable, observable } from 'mobx';
import { z } from 'zod';
import { toast } from '@/hooks/use-toast';
import type { IAuthApi } from '@/services/api/auth/authApi';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { ISignUpPayload } from '@/data/abstractions/ISignUpPayload';

export interface ISignUpFormVM {
  isLoading: boolean;
  setIsLoading: (isLoading: boolean) => void;
  isPasswordShown: boolean;
  togglePasswordShown: () => void;
  signUp: (data: z.infer<any>) => void;
  schemaSignUpForm: z.ZodObject<any>;
}

@injectable()
class SignUpFormVM implements ISignUpFormVM {
  @observable
  public isLoading: boolean = false;

  @observable
  public isPasswordShown: boolean = false;

  private formData: z.infer<typeof this.schemaSignUpForm> | null = null;

  private readonly authApi: IAuthApi;

  constructor(
    @inject(ServiceSymbols.AuthApi) authApi: IAuthApi
  ) {
    this.authApi = authApi;

    makeObservable(this);
  }

  @action
  public togglePasswordShown = () => {
    this.isPasswordShown = !this.isPasswordShown;
  };

  @action
  public setIsLoading = (isLoading: boolean) => {
    this.isLoading = isLoading;
  };

  @action
  public signUp = async (data: z.infer<typeof this.schemaSignUpForm>) => {
    this.formData = data;
    this.sendSignUpRequest();
  };

  @action.bound
  public sendSignUpRequest = flow(function* (this: SignUpFormVM) {
    if (this.formData === null)
      return;

    const payload: ISignUpPayload = {
      username: this.formData.username,
      password: this.formData.password,
      firstName: this.formData.firstName,
      lastName: this.formData.lastName,
      birthday: '2000-01-01'
    };

    try {
      this.formData = null;
      this.setIsLoading(true);
      yield this.authApi.signUp(payload);

      toast({
        title: 'Вход выполнен',
        description: 'Добро пожаловать! Вы успешно вошли в свою учетную запись.'
      });
      window.location.href = '/';
    } catch (e) {
      toast({
        variant: 'destructive',
        title: 'Ошибка входа',
        description: 'Неверное имя пользователя или пароль. Пожалуйста, проверьте свои учетные данные и попробуйте снова.'
      });
    } finally {
      this.setIsLoading(false);
    }
  });

  public readonly schemaSignUpForm: z.ZodObject<any> = z
    .object({
      username: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(4, 'Имя должно содержать не менее 4 символов'),
      password: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(6, 'Пароль должен содержать не менее 6 символов'),
      firstName: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(2, 'Имя должно содержать не менее 2 символов'),
      lastName: z
        .string({ required_error: 'Поле должно быть заполнено' })
        .min(2, 'Фамилия должна содержать не менее 2 символов')
    });
}

export default SignUpFormVM;
