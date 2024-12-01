'use client';

import { FC } from 'react';
import { cn } from '@/lib/utils';
import { IProblem } from '@/data/abstractions/IProblem';
import { Card, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import Image from 'next/image';
import bg1 from './images/bg1.jpg';
import bg2 from './images/bg2.jpg';
import bg3 from './images/bg3.jpg';
import bg4 from './images/bg4.jpg';
import bg5 from './images/bg5.jpg';
import moment from 'moment';
import { Badge } from '@/components/ui/badge';
import { useRouter } from 'next/navigation';

interface IProblemCardProps {
  className?: string;
  problem: IProblem;
}

export const ProblemCard: FC<IProblemCardProps> = ({ problem, className }) => {
  const bgs = [bg1, bg2, bg3, bg4, bg5];

  const getRandomBg = () => {
    const index = Math.round(Math.random() * 5) % 5;
    return bgs[index];
  };

  const getDifficultyBadge = (difficulty: number) => {
    switch (difficulty) {
      case 0:
        return <Badge className="bg-green-600 text-foreground">Легко</Badge>;
      case 1:
        return <Badge className="bg-orange-600 text-foreground">Средне</Badge>;
      case 2:
        return <Badge variant="destructive">Сложно</Badge>;
      default:
        return <></>;
    }
  };

  const router = useRouter();

  return (
    <Card
      className={cn('cursor-pointer hover:outline transition-all', className)}
      onClick={() => router.push(`/${problem.id}`)}
    >
      <CardHeader>
        <div className="flex items-center justify-between mb-2">
          {getDifficultyBadge(problem.difficulty)}
          <p className="text-right text-muted-foreground mt-2 text-sm">
            {moment(problem.openedAt).format('DD.MM.YYYY')}
          </p>
        </div>
        <Image src={getRandomBg()} width={150} height={150} alt={''} className="w-full rounded-md" />
      </CardHeader>
      <CardFooter>
        <CardTitle>{problem.name}</CardTitle>
      </CardFooter>
    </Card>
  );
};
