using System;
using System.Threading;
using System.Diagnostics;
namespace ThreadPooling
{
    class Program
    {

        static Random r = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("[{0}] Main called", Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(Status, i);
            }

            Thread.Sleep(4500);
            Console.WriteLine("[{0}] Main Done", Thread.CurrentThread.ManagedThreadId);


            Thread.Sleep(7000);

            for (int z = 0; z < 50000; z++)
            {
                ThreadPool.QueueUserWorkItem(Status, z);
            }

            Console.ReadKey();
        }

        
        static string ThreadIsBackgrund(object arg)
        {
            return Thread.CurrentThread.IsBackground.ToString();
        }
        static string ThreadIsAlive(object arg)
        {
            return Thread.CurrentThread.IsAlive.ToString();
        }

        static string PriorityOfTread(object arg)
        {
            return Thread.CurrentThread.Priority.ToString();
        }

        static void SetRandomThreadPriority(object arg)
        {
            int p = r.Next(0, 5);
            if (p == 0) { Thread.CurrentThread.Priority = ThreadPriority.Lowest; }
            else if (p == 1) { Thread.CurrentThread.Priority = ThreadPriority.BelowNormal; }
            else if (p == 2) { Thread.CurrentThread.Priority = ThreadPriority.Normal; }
            else if (p == 3) { Thread.CurrentThread.Priority = ThreadPriority.AboveNormal; }
            else if (p == 4) { Thread.CurrentThread.Priority = ThreadPriority.Highest; ; }
        }

        static void Status(object arb)
        {
            Thread.Sleep(r.Next(250, 500));

            SetRandomThreadPriority(arb);

            Console.WriteLine("ThreadID:{0} Priority:{1} IsAlive:{2} IsBackground:{3}", Thread.CurrentThread.ManagedThreadId, PriorityOfTread(arb),  ThreadIsAlive(arb), ThreadIsBackgrund(arb));
        }


    }
}