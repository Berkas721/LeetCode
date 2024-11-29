'use client';


import React, { FC } from 'react';
import { cn } from '@/lib/utils';
import { Logo } from '@/components/ui/logo';
import { Avatar, AvatarFallback, AvatarImage } from '@/components/ui/avatar';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem, DropdownMenuLabel,
  DropdownMenuTrigger
} from '@/components/ui/dropdown-menu';
import { Button } from '@/components/ui/button';
import useGet from '@/hooks/use-get';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IHeaderVM } from '@/components/shared/main/header/header.vm';

interface IHeaderProps {
  className?: string;
}

export const Header: FC<IHeaderProps> = ({ className }) => {
  const vm = useGet<IHeaderVM>(ServiceSymbols.IHeaderVM);

  return (
    <div className={cn('sticky flex flex-row h-16 justify-center border-b-white/10 border-b', className)}>
      <div className="px-8 py-2 max-w-[1200px] w-full h-full items-center flex justify-between">
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
                    <AvatarFallback>CN</AvatarFallback>
                  </Avatar>
                </DropdownMenuTrigger>
                <DropdownMenuContent>
                  <DropdownMenuLabel>{vm.user.userName}</DropdownMenuLabel>
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
        </div>
      </div>
    </div>
  );
};
