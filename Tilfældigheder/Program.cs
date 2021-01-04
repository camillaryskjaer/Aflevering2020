using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;

namespace Tilfældigheder
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Amount of numbers generated
            int iterations = 1000000;
            int value = new int();


            //RNGCryptoServiceProvider timer
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            Stopwatch rngstopWatch = new Stopwatch();
            byte[] data = new byte[4];
            Thread.Sleep(1000);
            rngstopWatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                rng.GetBytes(data);

                value = BitConverter.ToInt32(data, 0);
                Console.WriteLine(value);
            }
            rngstopWatch.Stop();
            TimeSpan rngts = rngstopWatch.Elapsed;

            Console.WriteLine("~~~~~~~~~~~~");

            //Random timer
            Random r = new Random();
            Stopwatch rstopWatch = new Stopwatch();
            Thread.Sleep(1000);
            rstopWatch.Start();
            for (int i = 0; i < iterations; i++)
            {
                value = r.Next(-999999999,999999999);
                Console.WriteLine(value);
            }
            rstopWatch.Stop();
            TimeSpan rts = rstopWatch.Elapsed;


            //placeholder variable
            string time = new string("");

            //Print timer for RNGCryptoServiceProvider function
            time = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", rngts.Hours, rngts.Minutes, rngts.Seconds, rngts.Milliseconds / 10);
            Console.WriteLine("RNGCryptoServiceProvider timer after " + iterations + " iterations:\n" + time);

            Console.WriteLine();

            //Print timer for Random Function
            time = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", rts.Hours, rts.Minutes, rts.Seconds, rts.Milliseconds / 10);
            Console.WriteLine("Random timer after " + iterations + " iterations:\n" + time);

            Console.ReadKey();
        }

        

    }
}
