'use client';

import React from 'react';

const ErrorPage = () => {
  return (
    <>
      <div className='flex flex-col gap-12 h-screen items-center justify-center content-center'>
        <p className='text-6xl'>🐤</p>
        <p className='items-center text-xl font-medium'>
          Страницы не существует:(
        </p>
      </div>
      <div className='flex gap-2 absolute bottom-10 w-full justify-center'>
        <p className='items-center text-xl font-medium'>PolyLeads</p>
      </div>
    </>
  );
};

export default ErrorPage;