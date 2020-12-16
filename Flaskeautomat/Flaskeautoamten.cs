using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        Random r = new Random();
        static Queue<string> sharedBuffer = new Queue<string>();

        static Queue<string> sodaBuffer = new Queue<string>();
        static Queue<string> beerBuffer = new Queue<string>();



        static void Main(string[] args)
        {
            Thread t1 = new Thread(Producer);
            t1.Start();

            Thread t2 = new Thread(Splitter);
            t2.Start();

            Thread t3 = new Thread(SodaConsumer);
            t3.Start();

            Thread t4 = new Thread(BeerConsumer);
            t4.Start();


            Console.ReadKey();
        }

        static void Producer()
        {
            while (true)
            {
                lock (sharedBuffer)
                {
                    sharedBuffer.Enqueue("Soda");
                    Console.WriteLine("TreadID[{0}] produced a Soda", Thread.CurrentThread.ManagedThreadId);
                    Monitor.PulseAll(sharedBuffer);
                }
                Thread.Sleep(2500);
                lock (sharedBuffer)
                {

                    sharedBuffer.Enqueue("Beer");
                    Console.WriteLine("TreadID[{0}] produced a Beer", Thread.CurrentThread.ManagedThreadId);
                    Monitor.PulseAll(sharedBuffer);
                }
                Thread.Sleep(2500);
            }
        }

        static void Splitter()
        {
            while (true)
            {
                lock (sharedBuffer)
                {
                    while (sharedBuffer.Count == 0)
                    {
                        Monitor.Wait(sharedBuffer);
                        Console.WriteLine("TreadID[{0}] is waiting for more objects to be produced...", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1000);
                    }
                    if (sharedBuffer.Peek() == "Soda")
                    {
                        lock (sodaBuffer)
                        {
                            Console.WriteLine("TreadID[{0}] moved a soda to the 'sodaBuffer'", Thread.CurrentThread.ManagedThreadId, sharedBuffer.Peek());
                            sodaBuffer.Enqueue(sharedBuffer.Dequeue());
                            Monitor.PulseAll(sodaBuffer);
                        }
                    }
                    else if (sharedBuffer.Peek() == "Beer")
                    {
                        lock (beerBuffer)
                        {
                            Console.WriteLine("TreadID[{0}] moved a beer to the 'beerBuffer'", Thread.CurrentThread.ManagedThreadId, sharedBuffer.Peek());
                            beerBuffer.Enqueue(sharedBuffer.Dequeue());
                            Monitor.PulseAll(beerBuffer);
                        }
                    }
                    else
                    {
                        while(true)
                        {
                            Console.WriteLine("error");
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
        static void SodaConsumer()
        {
            while (true)
            {
                lock (sodaBuffer)
                {
                    while (sodaBuffer.Count == 0)
                    {
                        Monitor.Wait(sodaBuffer);
                        Console.WriteLine("TreadID[{0}] is waiting for a soda...", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1000);
                    }
                    
                    Console.WriteLine("TreadID[{0}] customer got a '{1}'! Yahuuu", Thread.CurrentThread.ManagedThreadId, sodaBuffer.Peek());
                    sodaBuffer.Dequeue();
                    
                }
                Thread.Sleep(1000);
            }
        }

        static void BeerConsumer()
        {
            while (true)
            {
                lock (beerBuffer)
                {
                    while (beerBuffer.Count == 0)
                    {
                        Monitor.Wait(beerBuffer);
                        Console.WriteLine("TreadID[{0}] is waiting for a soda...", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1000);
                    }

                    Console.WriteLine("TreadID[{0}] customer got a '{1}'! Yahuuu", Thread.CurrentThread.ManagedThreadId, beerBuffer.Peek());
                    beerBuffer.Dequeue();

                }
                Thread.Sleep(1000);
            }
        }

        
    }
}
