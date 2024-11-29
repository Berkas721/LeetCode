'use client'

import DependencyContainer, { createDependencyContainer } from "@/context/dependencyContainer";
import { Container } from "inversify";
import { ThemeProvider } from '@/components/theme-provider';
import { Toaster } from '@/components/ui/toaster';
import localFont from 'next/font/local';


const geistSans = localFont({
  src: './fonts/GeistVF.woff',
  variable: '--font-geist-sans',
  weight: '100 900'
});
const geistMono = localFont({
  src: './fonts/GeistMonoVF.woff',
  variable: '--font-geist-mono',
  weight: '100 900'
});

export const App = ({ children }: Readonly<{ children: React.ReactNode }>) => {
  const dependencyContainer: Container = createDependencyContainer();

  return (
    <DependencyContainer.Provider value={dependencyContainer}>
      <body
        className={`${geistSans.variable} ${geistMono.variable} antialiased`}
      >
      <ThemeProvider
        attribute="class"
        defaultTheme="system"
        enableSystem
        disableTransitionOnChange
      >
        <main className='w-full font-[family-name:var(--font-geist-sans)]'>{children}</main>
        <Toaster />
      </ThemeProvider>
      </body>
    </DependencyContainer.Provider>
  );
};