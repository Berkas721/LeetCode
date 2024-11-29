import { FC } from 'react';
import { observer } from 'mobx-react-lite';
import { ResizableHandle, ResizablePanel, ResizablePanelGroup } from '@/components/ui/resizable';
import Editor from '@monaco-editor/react';
import { IProblemSolvingVM } from '@/components/shared/main/problem-solving/problem-solving.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import useGet from '@/hooks/use-get';
import { Button } from '@/components/ui/button';
import { Badge } from '@/components/ui/badge';
import moment from 'moment/moment';

interface IProblemSolvingProps {
  problemId: number;
}

const ProblemSolving: FC<IProblemSolvingProps> = ({ problemId }) => {
  const vm = useGet<IProblemSolvingVM>(ServiceSymbols.IProblemSolvingVM);

  vm.setProblemId(problemId);

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

  return (
    <div className="w-full h-[92%] p-2">
      <ResizablePanelGroup direction="horizontal" className="h-full border rounded-lg">
        <ResizablePanel minSize={30} defaultSize={40} className="flex flex-col gap-4 p-4">
          <div className="inline-flex w-full justify-between">
            {getDifficultyBadge(vm.problem.difficulty)}
            <p className="text-muted-foreground">
              {moment(vm.problem.openedAt).format('DD.MM.YYYY')}
            </p>
          </div>
          <h1 className='text-3xl font-semibold'>{vm.problem.name}</h1>
          <p>{vm.problem.description}</p>
        </ResizablePanel>
        <ResizableHandle withHandle />
        <ResizablePanel minSize={40} defaultSize={60} className="flex flex-col gap-4 p-4">
          <div className='flex justify-between flex-row'>
            <Button>Запустить с тестовыми данными</Button>
            <Button variant='secondary'>Отправить на проверку</Button>
          </div>
          <Editor
            className="h-full"
            defaultLanguage="csharp"
            value={vm.code}
            theme={'vs-dark'}
            onChange={(value) => {
              vm.setCode(value);
            }}
            options={{
              minimap: { enabled: false },
              insertSpaces: true,
              tabSize: 4,
              lineNumbers: 'on'
            }}
          />
        </ResizablePanel>
      </ResizablePanelGroup>
    </div>
  );
};

export default observer(ProblemSolving);