import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import Link from 'next/link';
import React from 'react';
import SignUpForm from '@/components/shared/auth/sign-up';

const Page = () => {
  return (
    <div className="flex h-screen w-full items-center justify-center px-4">
      <Card className="mx-auto max-w-sm">
        <CardHeader>
          <CardTitle className="text-2xl">Регистрация</CardTitle>
          <CardDescription>
            Введите данные для регистрации, чтобы создать новую учетную запись
          </CardDescription>
        </CardHeader>
        <CardContent>
          <SignUpForm />
        </CardContent>
        <CardFooter className='flex items-center justify-center font-normal text-sm'>
          <Link href='/sign-in' className="underline">У меня уже есть аккаунт</Link>
        </CardFooter>
      </Card>
    </div>
  );
};

export default Page;