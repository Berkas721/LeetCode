import { FC, useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import { ResizableHandle, ResizablePanel, ResizablePanelGroup } from '@/components/ui/resizable';
import Editor from '@monaco-editor/react';
import { IProblemSolvingVM } from '@/components/shared/main/problem-solving/problem-solving.vm';
import ServiceSymbols from '@/data/constant/ServiceSymbols';
import useGet from '@/hooks/use-get';
import { Button } from '@/components/ui/button';
import { Badge } from '@/components/ui/badge';
import moment from 'moment/moment';
import { Skeleton } from '@/components/ui/skeleton';
import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogTrigger
} from '@/components/ui/alert-dialog';

interface IProblemSolvingProps {
  problemId: number;
}

const ProblemSolving: FC<IProblemSolvingProps> = ({ problemId }) => {
  const vm = useGet<IProblemSolvingVM>(ServiceSymbols.IProblemSolvingVM);

  useEffect(() => {
    if (vm && problemId) {
      vm.setProblemId(problemId);
    }
  }, [vm, problemId]);

  const getDifficultyBadge = (difficulty: number) => {
    switch (difficulty) {
      case 0:
        return <Badge className="bg-green-600 dark:text-foreground text-background">Легко</Badge>;
      case 1:
        return <Badge className="bg-orange-600 dark:text-foreground text-background">Средне</Badge>;
      case 2:
        return <Badge variant="destructive">Сложно</Badge>;
      default:
        return <></>;
    }
  };

  const formatJsonString = (json: string): string => {
    try {
      const parsedObject = JSON.parse(json);
      return Object.entries(parsedObject)
        .map(([key, value]) => `${key} = ${value}`)
        .join(', ');
    } catch (error) {
      return 'Invalid JSON string';
    }
  };

  return (
    <div className="w-full h-[92%] p-2">
      <ResizablePanelGroup direction="horizontal" className="h-full border rounded-lg">
        <ResizablePanel minSize={30} defaultSize={40} className="flex flex-col gap-4">
          <ResizablePanelGroup direction="vertical" className="h-full">
            <ResizablePanel minSize={60} defaultSize={70} className="flex flex-col gap-4 p-8">
              {
                vm.problem
                  ? <>
                    <div className="inline-flex w-full justify-between">
                      {getDifficultyBadge(vm.problem.difficulty)}
                      <p className="text-muted-foreground">
                        {moment(vm.problem.createdAt).format('DD.MM.YYYY')}
                      </p>
                    </div>
                    <h1 className="text-3xl font-semibold">{vm.problem.name}</h1>
                    <p>{vm.problem.description}</p>
                    <div className="flex flex-col gap-2 mt-8">
                      {
                        vm.testcases && (vm.testcases.length > 0) && vm.testcases.map((t, index) => (
                          <div className="mb-4" key={index}>
                            <p className="font-bold">Пример {index + 1}:</p>
                            <p className="ml-4">Input: {formatJsonString(t.input)}.</p>
                            <p className="ml-4">Output: {formatJsonString(t.output)}.</p>
                          </div>
                        ))
                      }
                    </div>
                  </>
                  : <Skeleton className="w-full h-full"></Skeleton>
              }
            </ResizablePanel>
            <ResizableHandle withHandle />
            <ResizablePanel minSize={20} defaultSize={30} className="flex flex-col gap-4 p-8">
              <Skeleton className="w-full h-full"></Skeleton>
            </ResizablePanel>
          </ResizablePanelGroup>
        </ResizablePanel>
        <ResizableHandle withHandle />
        <ResizablePanel minSize={30} defaultSize={60} className="flex flex-col gap-4">
          <ResizablePanelGroup direction="vertical" className="h-full">
            <ResizablePanel minSize={40} defaultSize={80} className="flex flex-col gap-4 p-8">
              <div className="flex justify-between flex-row">
                <Button>Запустить с тестовыми данными</Button>
                <AlertDialog>
                  <AlertDialogTrigger asChild>
                    <Button variant="secondary">Отправить решение на проверку</Button>
                  </AlertDialogTrigger>
                  <AlertDialogContent>
                    <AlertDialogHeader>
                      <AlertDialogTitle>Вы уверены?</AlertDialogTitle>
                      <AlertDialogDescription>
                        После отправки решения на проверку изменить его будет невозможно.
                      </AlertDialogDescription>
                    </AlertDialogHeader>
                    <AlertDialogFooter>
                      <AlertDialogCancel>Отмена</AlertDialogCancel>
                      <AlertDialogAction>Продолжить</AlertDialogAction>
                    </AlertDialogFooter>
                  </AlertDialogContent>
                </AlertDialog>
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
            <ResizableHandle withHandle />
            <ResizablePanel minSize={10} defaultSize={20} className="flex flex-col gap-4 p-8">
              <Skeleton className="w-full h-full"></Skeleton>
            </ResizablePanel>
          </ResizablePanelGroup>
        </ResizablePanel>
      </ResizablePanelGroup>
    </div>
  );
};

export default observer(ProblemSolving);