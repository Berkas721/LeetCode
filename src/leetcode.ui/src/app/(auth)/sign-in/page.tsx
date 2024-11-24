import SignInForm from '@/components/shared/auth/sign-in';
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import Link from 'next/link';
import React from 'react';

const SignInPage = () => {
  return (
    <div className="flex h-screen w-full items-center justify-center px-4">
      <Card className="mx-auto max-w-sm">
        <CardHeader>
          <CardTitle className="text-2xl">Вход</CardTitle>
          <CardDescription>
            Введите данные для входа, чтобы войти в свою учетную запись
          </CardDescription>
        </CardHeader>
        <CardContent>
          <SignInForm />
        </CardContent>
        <CardFooter className='flex items-center justify-center font-normal text-sm'>
          <Link href='/sign-up' className="underline">Создать учетную запись</Link>
        </CardFooter>
      </Card>
    </div>
  );
};

export default SignInPage;