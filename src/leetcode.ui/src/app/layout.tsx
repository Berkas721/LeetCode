import 'reflect-metadata';
import { Metadata } from 'next';
import './globals.css';
import { App } from './app';

export const metadata: Metadata = {
  title: 'LeetCode',
  authors: [{ name: 'OnlySpans', url: '/' }],
};

const RootLayout = ({ children }: Readonly<{ children: React.ReactNode }>) => {
  return (
    <html lang="en">
      <App>
        {children}
      </App>
    </html>
  );
}

export default RootLayout;
