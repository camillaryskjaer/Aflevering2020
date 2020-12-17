using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        //shared variable
        static Queue<string> products = new Queue<string>();

        static void Main(string[] args)
        {
            //start producer thread
            Thread t1 = new Thread(Produce);
            t1.Start();

            //start consumer thread
            Thread t2 = new Thread(Consume);
            t2.Start();

            Console.ReadKey();
        }

        static void Produce()
        {
            //never stop running
            while (true)
            {
                //takes the lock
                lock (products)
                {
                    //temp var for the sake of cw
                    int temp = 0;
                    //go into while loop that runs untill 3 items has been produced
                    while (products.Count != 3)
                    {
                        //enqueue a product in the queue of strings with the name Product
                        products.Enqueue("Product");
                        temp++;
                        //ThreadID:x produced product #x 'string'
                        Console.WriteLine("ThreadID:{0} produced product #{2} '{1}'", Thread.CurrentThread.ManagedThreadId, products.Peek(), temp);
                        Thread.Sleep(100);
                    }
                    //out of the production loop since the desired amount of products has been accomplished
                    //let other threads know that products is free to take
                    Monitor.PulseAll(products);
                    //goes into waiting position, untill prodcuts need to be replenished
                    while (products.Count >= 3)
                    {
                        Monitor.Wait(products);
                        Console.WriteLine("Producer is waiting...");
                    }
                }
                Thread.Sleep(500);
            }
        }

        static void Consume()
        {   
            //never stop running
            while (true)
            {
                //takes the lock
                lock (products)
                {   //temp var for the sake of cw
                    int temp = 0;
                    //go into while loop that runs untill all items has been consumed
                    while (products.Count != 0)
                    {
                        temp++;
                        Console.WriteLine("ThreadID:{0} consumed product #{2} '{1}'", Thread.CurrentThread.ManagedThreadId, products.Peek(), temp);
                        //Dequeue first product in the queue of strings
                        products.Dequeue();
                        Thread.Sleep(100);
                    }
                    //out of the consumtion loop since there is no more products to consume
                    //let other threads know that products is free to take
                    Monitor.PulseAll(products);
                    //goes into waiting position, untill products are replenished
                    while (products.Count == 0)
                    {
                        Monitor.Wait(products);
                        Console.WriteLine("Consumer is waiting...");
                    }
                }
                Thread.Sleep(250);
            }
        }



    }
}
