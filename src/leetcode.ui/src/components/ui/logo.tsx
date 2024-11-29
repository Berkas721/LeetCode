import { FC } from 'react';
import { cn } from '@/lib/utils';
import { CodeXml } from 'lucide-react';

interface ILogoProps {
	className?: string;
}

export const Logo: FC<ILogoProps> = ({ className }) => {
	return (
		<div className={cn('inline-flex gap-2', className)}>
			<CodeXml />
			LeetCode
		</div>
	);
};
