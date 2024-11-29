import { Header } from '@/components/shared/main/header/header';
import { ProblemsLib } from '@/components/shared/main/home-page/problems-lib/problems-lib';

export default function Home() {
  return (
    <>
      <Header />
      <div className="flex w-full min-h-screen justify-center gap-8 row-start-2">
        <div className="max-w-[1200px] px-8 mb-16 w-full mt-16">
          <h3 className="font-semibold text-4xl mb-4">Добро пожаловать!</h3>
          <h4 className="mb-16">
            На нашем сайте вы найдете множество интересных и разнообразных задач по программированию. Каждая задача —
            это возможность проверить свои навыки, улучшить знания, и освоить новые для себя алгоритмы и подходы.
          </h4>
          <ProblemsLib />
        </div>
      </div>
    </>
  );
}
