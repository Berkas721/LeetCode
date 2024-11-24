import { useContext, useMemo } from 'react';
import DependencyContainer from '@/context';

const useGet = <TType>(symbol: symbol): TType => {
  const container = useContext(DependencyContainer);
  const value = useMemo(() => container.get<TType>(symbol), []);

  return value;
};

export default useGet;