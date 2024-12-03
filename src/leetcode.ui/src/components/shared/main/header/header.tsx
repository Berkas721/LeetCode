'use client';

import React, { FC } from 'react';
import { cn } from '@/lib/utils';
import { Logo } from '@/components/ui/logo';
import { Avatar, AvatarFallback, AvatarImage } from '@/components/ui/avatar';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem, DropdownMenuLabel, DropdownMenuSeparator,
  DropdownMenuTrigger
} from '@/components/ui/dropdown-menu';
import { Button } from '@/components/ui/button';
import useGet from '@/hooks/use-get';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IHeaderVM } from '@/components/shared/main/header/header.vm';
import { observer } from 'mobx-react-lite';
import { ThemeToggleButton } from '@/components/ui/theme-toggle-button';

interface IHeaderProps {
  className?: string;
  isFullWidth?: boolean;
}

const Header: FC<IHeaderProps> = ({ className, isFullWidth = false }) => {
  const vm = useGet<IHeaderVM>(ServiceSymbols.IHeaderVM);

  return (
    <div
      className={cn('sticky top-0 flex flex-row h-16 justify-center dark:border-b-white/10 border-b-black/10 border-b bg-background/40 backdrop-blur', className)}>
      <div
        className={cn(
          'px-8 py-2  w-full h-full items-center flex justify-between',
          !isFullWidth && 'max-w-[1200px]'
        )}
      >
        <a href={'/'} className="no-underline flex items-center hover:bg-accent transition-all">
          <Logo />
        </a>
        <div className="inline-flex items-center gap-3">
          {
            vm.user ?
              <DropdownMenu>
                <DropdownMenuTrigger>
                  <Avatar className="hover:outline-1 outline-white outline-2">
                    <AvatarImage src="https://github.com/shadcn.png" />
                    <AvatarFallback>:P</AvatarFallback>
                  </Avatar>
                </DropdownMenuTrigger>
                <DropdownMenuContent>
                  <DropdownMenuLabel className="font-semibold">Привет, {vm.user.userName}!</DropdownMenuLabel>
                  <DropdownMenuSeparator></DropdownMenuSeparator>
                  <DropdownMenuItem onClick={vm.signOut}>Выйти</DropdownMenuItem>
                </DropdownMenuContent>
              </DropdownMenu>
              : <>
                <a href={'/sign-up'}>
                  <Button>Регистрация</Button>
                </a>
                <a href={'/sign-in'}>
                  <Button variant="secondary">Вход</Button>
                </a>
              </>
          }
          <ThemeToggleButton />
        </div>
      </div>
    </div>
  );
};

export default observer(Header);