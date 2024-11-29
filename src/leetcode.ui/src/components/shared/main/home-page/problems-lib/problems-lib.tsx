import { FC } from 'react';
import { cn } from '@/lib/utils';
import { IProblem } from '@/data/abstractions/IProblem';
import { ProblemCard } from '@/components/shared/main/home-page/problem-card/problem-card';

interface IProblemsLibProps {
	className?: string;
}

export const ProblemsLib: FC<IProblemsLibProps> = ({ className }) => {
	
	const problems: IProblem[] = [
		{
			"id": 1,
			"name": "Задача для тестов",
			"description": "Напишите код для сложения a и b.",
			"difficulty": 0,
			"status": 2,
			"creatorId": "d1e79568-09d0-4798-a549-38498afd7969",
			"createdAt": "2024-11-20T16:29:21.649961Z",
			"updaterId": "d1e79568-09d0-4798-a549-38498afd7969",
			"updatedAt": "2024-11-28T17:49:23.279926Z",
			"openerId": "d1e79568-09d0-4798-a549-38498afd7969",
			"openedAt": "2024-11-28T17:49:23.279158Z"
		},
		{
			"id": 2,
			"name": "Определение простого числа",
			"description": "Напишите функцию, которая проверяет, является ли число простым.",
			"difficulty": 1,
			"status": 1,
			"creatorId": "a4c8f690-b7e1-412f-9f76-e2fbb582f89e",
			"createdAt": "2024-11-15T10:15:00.000000Z",
			"updaterId": "a4c8f690-b7e1-412f-9f76-e2fbb582f89e",
			"updatedAt": "2024-11-16T14:30:00.000000Z",
			"openerId": "a4c8f690-b7e1-412f-9f76-e2fbb582f89e",
			"openedAt": "2024-11-16T14:45:00.000000Z"
		},
		{
			"id": 3,
			"name": "Поиск максимального элемента",
			"description": "Реализуйте алгоритм для поиска максимального числа в массиве.",
			"difficulty": 1,
			"status": 0,
			"creatorId": "b3df4568-d93e-4aa5-8d3c-b5f6d59af7e2",
			"createdAt": "2024-10-30T08:25:43.829472Z",
			"updaterId": "b3df4568-d93e-4aa5-8d3c-b5f6d59af7e2",
			"updatedAt": "2024-11-01T12:00:00.000000Z",
			"openerId": "b3df4568-d93e-4aa5-8d3c-b5f6d59af7e2",
			"openedAt": "2024-11-01T12:05:00.000000Z"
		},
		{
			"id": 4,
			"name": "Сортировка массива",
			"description": "Напишите алгоритм для сортировки массива чисел.",
			"difficulty": 2,
			"status": 0,
			"creatorId": "c2e87653-f8c1-4b67-9c9d-614a2cf34a1e",
			"createdAt": "2024-09-20T14:00:00.000000Z",
			"updaterId": "c2e87653-f8c1-4b67-9c9d-614a2cf34a1e",
			"updatedAt": "2024-09-21T09:00:00.000000Z",
			"openerId": "c2e87653-f8c1-4b67-9c9d-614a2cf34a1e",
			"openedAt": "2024-09-21T10:00:00.000000Z"
		},
		{
			"id": 5,
			"name": "Факториал числа",
			"description": "Напишите функцию, которая вычисляет факториал числа.",
			"difficulty": 0,
			"status": 1,
			"creatorId": "f4c9b5e1-cd9d-47a1-b81a-7e5f5ecf9abc",
			"createdAt": "2024-11-27T11:45:00.123456Z",
			"updaterId": "f4c9b5e1-cd9d-47a1-b81a-7e5f5ecf9abc",
			"updatedAt": "2024-11-28T08:00:00.987654Z",
			"openerId": "f4c9b5e1-cd9d-47a1-b81a-7e5f5ecf9abc",
			"openedAt": "2024-11-28T08:05:00.123456Z"
		}
	]


	return (
		<div className={cn('flex w-full flex-col gap-8', className)}>
			<h3 className='font-semibold text-2xl'>Задачи:</h3>
			<div className={'w-full grid gap-8 grid-cols-3'}>
				{problems.map(problem => (
					<ProblemCard problem={problem}/>
				))}
			</div>
		</div>
	);
};
