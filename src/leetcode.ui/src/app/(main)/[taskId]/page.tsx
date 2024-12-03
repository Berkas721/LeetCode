'use client';

import Header from '@/components/shared/main/header/header';
import ProblemSolving from '@/components/shared/main/problem-solving/problem-solving';


export default function Page({ params }: { params: { taskId: number } }) {
  return <>
    <Header isFullWidth={true} />
    <ProblemSolving problemId={params.taskId} />
  </>;
}