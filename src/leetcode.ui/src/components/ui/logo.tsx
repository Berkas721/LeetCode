import { FC } from 'react';
import { cn } from '@/lib/utils';
import { CodeXml } from 'lucide-react';

interface ILogoProps {
	className?: string;
}

export const Logo: FC<ILogoProps> = ({ className }) => {
	return (
		<div className={cn('inline-flex gap-2 items-center', className)}>
			<CodeXml />
			<h1 className='font-bold text-xl'>LeetCode</h1>
		</div>
	);
};
