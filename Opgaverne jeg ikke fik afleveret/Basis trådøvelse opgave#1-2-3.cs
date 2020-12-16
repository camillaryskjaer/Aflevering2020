using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trådøvelse
{
    class Program
    {
        static void Main(string[] args)
        {
            //create new thread #1
            Thread thread1 = new Thread(new ThreadStart(WorkForThreadOne));
            Thread thread2 = new Thread(new ThreadStart(WorkForThreadTwo));
            Thread thread3 = new Thread(new ThreadStart(WorkForThreadTree));
            thread1.Start();
            thread2.Start();
            thread3.Start();

            while(thread3.IsAlive)
            {
                Thread.Sleep(10000);
            }

            Console.WriteLine("Alarm-tråd termineret!");
            Console.ReadKey();
        }

        //Function that the threads work on.
        static public void WorkForThreadOne()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ThreadID[{0}] ~ C#-trådning er nemt!", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }
        }

        static public void WorkForThreadTwo()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("ThreadID[{0}] ~ Også med flere tråde …", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }
        }

        static public void WorkForThreadTree()
        {
            Random r = new Random();
            int warnings = 0;


            while(warnings != 3)
            {
                int tempTemperature = r.Next(-20, 121);
                Console.Write("ThreadID[{0}] ~ Temperature generated: {1} ", Thread.CurrentThread.ManagedThreadId, tempTemperature);
                if (tempTemperature >= 0)
                {
                    Console.WriteLine("Status: Temperature is safe");
                }
                else if(tempTemperature < 0)
                {
                    warnings++;
                    Console.WriteLine("Status: Temperature too high! Warning #{0} ", warnings);
                }
                Console.WriteLine();
                Thread.Sleep(2000);
            }
        }
    }
}