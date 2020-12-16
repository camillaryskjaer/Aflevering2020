using System;
using System.Threading;


namespace Tråd2
{
    class Program
    {
        static int[] plate = new int[5];
        static object[] fork = new object[5];
        static Random r = new Random();
        static void Main(string[] args)
        {
            //create forks for the fork array
            //puts 50 spaghetti strings onto the plate
            for (int i = 0; i < 5; i++)
            {
                plate[i] = 2;
                fork[i] = true;
            }

            //5 threads calling spaghetii function
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(Spaghetti, i);
            }

            Console.ReadKey();

        }

        static void Spaghetti(object arg)
        {
            int p = (int)arg;
            
            //run while there is spaghetti on the plate.
            while (plate[p] != 0)
            {
                //Philosopher is thinking
                Console.WriteLine("Philospher[{0}] Is thinking...", p + 1, Math.Min(p, (p + 1) % 5));
                Thread.Sleep(r.Next(5000));
                //Philosopher picks up first fork
                lock (fork[Math.Min(p, (p + 1) % 5)])
                {
                    //Philosopher picks up second fork
                    Console.WriteLine("Philospher[{0}] picked up fork[{1}]", p + 1, Math.Min(p, (p + 1) % 5) + 1);
                    lock (fork[Math.Max(p, (p + 1) % 5)])
                    {
                        Thread.Sleep(200);
                        Console.WriteLine("Philospher[{0}] picked up fork[{1}]", p + 1, Math.Max(p, (p + 1) % 5)+1);
                        Thread.Sleep(200);
                        Console.WriteLine("Philospher[{0}] starts eating", p + 1);
                        Thread.Sleep(5000);
                        //Philosopher has eaten a spagetti string
                        plate[p]--;
                        Console.WriteLine("Philospher[{0}] is done eating", p + 1);


                        Thread.Sleep(350);
                        //Philosopher puts down fork
                        Console.WriteLine("Philospher[{0}] puts down fork[{1}]", p + 1, Math.Max(p, (p + 1) % 5) + 1);
                    }
                    Thread.Sleep(500);
                    //Philosopher puts down fork
                    Console.WriteLine("Philospher[{0}] puts down fork[{1}]", p+1, Math.Min(p, (p + 1) % 5) + 1);
                }

            }
            //Philosophers plate is empty
            Console.WriteLine("Philospher[{0}] plate is empty, there is NO MORE SPAGHETTI", p + 1);
        }

    }
}
