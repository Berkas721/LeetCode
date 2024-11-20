'use client';

import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';
import React from 'react';
import useGet from '@/hooks/use-get';
import { observer } from 'mobx-react-lite';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { z } from 'zod';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormMessage
} from '@/components/ui/form';
import { EyeIcon, EyeOffIcon, LoaderCircle } from 'lucide-react';
import { ISignUpFormVM } from './sign-up-form.vm';


interface ISignUpProps {
}

const SignUpForm: React.FC<ISignUpProps> = () => {
  const vm = useGet<ISignUpFormVM>(ServiceSymbols.ISignUpFormVM);

  const form = useForm<z.infer<typeof vm.schemaSignUpForm>>({
    resolver: zodResolver(vm.schemaSignUpForm)
  });

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(vm.signUp)}
        className="grid gap-2"
      >
        <FormField
          control={form.control}
          name="username"
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <Input
                  id="username"
                  placeholder="Имя пользователя"
                  autoComplete="username"
                  autoCorrect="off"
                  disabled={vm.isLoading}
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="password"
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <div className="relative">
                  <Input
                    id="password"
                    type={vm.isPasswordShown ? 'text' : 'password'}
                    placeholder="Пароль"
                    autoComplete="new-password"
                    autoCorrect="off"
                    disabled={vm.isLoading}
                    {...field}
                  />
                  <Button
                    type="button"
                    variant="ghost"
                    className="absolute top-0 right-0 px-3 py-2 hover:bg-transparent"
                    onClick={vm.togglePasswordShown}
                    disabled={vm.isLoading}
                  >
                    {vm.isPasswordShown ? (
                      <EyeOffIcon className="h-4 w-4" />
                    ) : (
                      <EyeIcon className="h-4 w-4" />
                    )}
                  </Button>
                </div>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="firstname"
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <Input
                  id="firstname"
                  placeholder="Имя"
                  autoComplete="firstname"
                  autoCorrect="off"
                  disabled={vm.isLoading}
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="lastname"
          render={({ field }) => (
            <FormItem>
              <FormControl>
                <Input
                  id="lastname"
                  placeholder="Фамилия"
                  autoComplete="lastname"
                  autoCorrect="off"
                  disabled={vm.isLoading}
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button
          type="submit"
          disabled={vm.isLoading}
        >
          {vm.isLoading ? (
            <>
              <LoaderCircle className="mr-2 h-4 w-4 animate-spin" />
              Подождите
            </>
          ) : (
            'Создать аккаунт'
          )}
        </Button>
        <Input
          className="hidden"
          type={vm.isPasswordShown ? 'text' : 'password'}
        />
      </form>
    </Form>
  );
};

export default observer(SignUpForm);
