import Link from 'next/link';

import { Button } from '@/components/ui/button';
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle
} from '@/components/ui/card';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';

export const SignInForm = () => {
  return (
    <Card className="mx-auto max-w-sm">
      <CardHeader>
        <CardTitle className="text-2xl">Вход</CardTitle>
        <CardDescription>
          Введите адрес электронной почты, чтобы войти в свою учетную запись
        </CardDescription>
      </CardHeader>
      <CardContent>
        <div className="grid gap-4">
          <div className="grid gap-2">
            <Label htmlFor="email">Email</Label>
            <Input
              id="email"
              type="email"
              placeholder="email@example.com"
              required
            />
          </div>
          <div className="grid gap-2">
            <Label htmlFor="password">Пароль</Label>
            <Input
              id="password"
              type="password"
              placeholder="******"
              required
            />
          </div>
          <Button type="submit" className="w-full">
            Войти
          </Button>
        </div>
        <div className="mt-4 text-center text-sm">
          <Link href="/sign-up" className="underline">
            Создать новую учетную запись
          </Link>
        </div>
      </CardContent>
    </Card>
  );
};
