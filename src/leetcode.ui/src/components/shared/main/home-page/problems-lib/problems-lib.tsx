'use client';

import { FC } from 'react';
import { cn } from '@/lib/utils';
import { ProblemCard } from '@/components/shared/main/home-page/problem-card/problem-card';
import useGet from '@/hooks/use-get';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import { IProblemsLibVM } from '@/components/shared/main/home-page/problems-lib/problems-lib.vm';
import { Skeleton } from '@/components/ui/skeleton';
import { observer } from 'mobx-react-lite';

interface IProblemsLibProps {
  className?: string;
}

const ProblemsLib: FC<IProblemsLibProps> = ({ className }) => {
  const vm = useGet<IProblemsLibVM>(ServiceSymbols.IProblemsLibVM);

  console.log(vm.isLoading);

  return (
    <div className={cn('flex w-full flex-col gap-8', className)}>
      <h3 className="font-semibold text-2xl">Задачи:</h3>
      <div className={'w-full grid gap-8 grid-cols-3'}>
        {
          vm.isLoading
            ? Array.from(Array(6).keys()).map(
              (x, index) => <Skeleton className="w-full h-[200px] rounded-md" key={index} />
            )
            : vm.problems.map(problem => (
              <ProblemCard problem={problem} key={problem.id} />
            ))
        }
      </div>
    </div>
  );
};

export default observer(ProblemsLib);
