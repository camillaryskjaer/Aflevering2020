using System;
using System.Threading;


namespace Tråd2
{
    class Program
    {
        static int count = 0;
        static object x = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(CountPlusPlus);
            Thread t2 = new Thread(CountMinus);

            
            t1.Start();
            t2.Start();
        }

        static void CountPlusPlus(object arg)
        {
            while (true)
            {
                Monitor.Enter(x);
                try
                {
                    count++;
                    Console.WriteLine("ThreadID:{0} | + + + | Total:{1}", Thread.CurrentThread.ManagedThreadId, count);
                    Thread.Sleep(500);
                    count++;
                    Console.WriteLine("ThreadID:{0} | + + + | Total:{1}", Thread.CurrentThread.ManagedThreadId, count);
                    Thread.Sleep(500);

                }
                finally
                {
                    Monitor.Exit(x);
                }

            }
        }

        static void CountMinus(object arg)
        {
            while (true)
            {
                Monitor.Enter(x);
                try
                {
                    count--;
                    Console.WriteLine("ThreadID:{0} | - - - | Total:{1}", Thread.CurrentThread.ManagedThreadId, count);
                    Thread.Sleep(1000);
                }
                finally
                {
                    Monitor.Exit(x);
                }

            }
        }
    }
}
