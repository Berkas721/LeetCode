import { ITestCase } from '@/data/abstractions/ITestCase';
import { IImplementedProblem } from '@/data/abstractions/IImplementedProblem';

export interface IProblemFull {
  id: number;
  name: string;
  description?: string;
  difficulty: number;
  status: number;
  creatorId: string;
  createdAt: Date;
  updaterId?: string;
  updatedAt?: Date;
  openerId?: string;
  openedAt?: Date;
  testCases: ITestCase[];
  implementedProblems: IImplementedProblem[];
}
