using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabase
{
    public class MultithreadingToDatabase
    {
        private bool acuiredlock = false;
        private AutoResetEvent wait_handler = new AutoResetEvent(true);
        private Mutex mutex = new Mutex();
        private Semaphore semaphore = new Semaphore(0,1);
        private DbContextOptions options;

        public MultithreadingToDatabase(DbContextOptions options)
        {
            this.options = options; 
        }

        public void Lock()
        {
            object? locker = new object();
            for (int i = 0; i < 11; i++)
            {
                using (LibraryContext context = new LibraryContext(options))
                {
                    Thread myThread = new Thread(() =>
                    {
                        lock (locker!)
                        {
                            context.Author.Add(new Entities.Author { surname_name_lastname = "some_author" + i });
                            context.SaveChanges();
                        }
                    });
                    myThread.Start();
                }
            }
        }

        public void Mutex()
        {
            for (int i = 0; i < 11; i++)
            {
                using (LibraryContext context = new LibraryContext(options))
                {
                    Thread mythread = new Thread(() =>
                    {
                        mutex.WaitOne();
                        context.Author.Add(new Entities.Author { surname_name_lastname = "sime_author" + i });
                        context.SaveChanges();
                        mutex.ReleaseMutex();
                    });
                    mythread.Start();
                }
            }
        }

        public void Semaphore()
        {
            for (int i = 0; i < 11; i++)
            {
                using (LibraryContext context = new LibraryContext(options))
                {
                    Thread myThread = new(() =>
                    {
                        semaphore.WaitOne();
                        context.Author.Add(new Entities.Author { surname_name_lastname = "sime_author" + i });
                        context.SaveChanges();
                        semaphore.Release();
                    });
                    myThread.Start();
                }
            }
        }

        public void monitor()
        {
            object? locker = new object();
            for (int i = 0; i < 11; i++)
            {
                using (LibraryContext context = new LibraryContext(options))
                {
                    Thread myThread = new Thread(() =>
                    {
                        bool acquiredlock = false;
                        try
                        {
                            Monitor.Enter(locker, ref acquiredlock);
                            context.Author.Add(new Entities.Author { surname_name_lastname = "some_author" + i });
                            context.SaveChanges();
                        }
                        finally
                        {
                            if (acquiredlock)
                            {
                                Monitor.Exit(locker);
                            }
                        }                        
                    });
                    myThread.Start();
                }
            }
        }

        public void AutoResetEvent()
        {
            for (int i = 0; i < 11; i++)
            {
                using (LibraryContext context = new LibraryContext(options))
                {
                    Thread myThread = new(() =>
                    {
                        wait_handler.WaitOne();
                        context.Author.Add(new Entities.Author { surname_name_lastname = "sime_author" + i });
                        context.SaveChanges();
                        wait_handler.Set();
                    });
                    myThread.Start();
                }
            }
        }
    }    
}
