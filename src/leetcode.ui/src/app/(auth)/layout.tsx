import { ThemeToggleButton } from '@/components/ui/theme-toggle-button';

const AuthLayout = ({ children }: Readonly<{ children: React.ReactNode }>) => {
  return (
    <div className='flex'>
      {children}
      <div className='absolute right-4 bottom-4'>
        <ThemeToggleButton/>
      </div>
    </div>
  );
}

export default AuthLayout;