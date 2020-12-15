using System;
using System.Threading;


namespace Tråd2
{
    class Program
    {
        static object x = new object();
        static void Main(string[] args)
        {

            Console.SetWindowSize(60, 20);

            Thread t1 = new Thread(Star);
            Thread t2 = new Thread(Fence);
            t1.Start();
            t2.Start();
        }

        static void Star(object arg)
        {
            while (true)
            {
                Monitor.Enter(x);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();

                }
                finally
                {
                    Monitor.Exit(x);
                    Thread.Sleep(100);
                }
            }
        }

        static void Fence(object arg)
        {
            while (true)
            {
                Monitor.Enter(x);
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();

                }
                finally
                {
                    Monitor.Exit(x);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
