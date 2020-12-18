using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {

        //shared variable
        static Random r = new Random();

        static string[] counter1 = new string[5];
        static string[] counter2 = new string[5];
        static string[] counter3 = new string[5];

        static Queue<string> sorter1 = new Queue<string>();

        static string[] terminal1 = new string[20];
        static string[] terminal2 = new string[20];
        static string[] terminal3 = new string[20];
        static void Main(string[] args)
        {
            //create threads simulating counters
            Thread c1 = new Thread(Counter);
            Thread c2 = new Thread(Counter);
            Thread c3 = new Thread(Counter);
            //create thread simluating baggage collecting from counters
            Thread cc1 = new Thread(CounterCollecter);
            //create thread simluating sorting
            Thread s1 = new Thread(Sorter);
            //create threads simulating terminals
            Thread t1 = new Thread(Terminal);
            Thread t2 = new Thread(Terminal);
            Thread t3 = new Thread(Terminal);
            //Thread sorting = new Thread(Sorter);

            //starting all threads
            c1.Start(counter1);
            c2.Start(counter2);
            c3.Start(counter3);
            //counter collecter start
            cc1.Start();
            //sorter
            s1.Start();
            //terminals
            t1.Start(terminal1);
            t2.Start(terminal2);
            t3.Start(terminal3);


            Console.ReadKey();
        }

        /// <summary>
        /// sorting moves them just like the soda/beer sorting thing, so every bagage for now should just have a destination. then i can make object later.
        /// </summary>
        /// 
        static void Counter(object arg)
        {
            string[] counter = (string[])arg;
            //never stop running
            while (true)
            {
                //simulating people walking up to the counter at random intervals
                Thread.Sleep(100);
                if (r.Next(100) == 1)
                    //acquire the lock
                    lock (counter)
                    {
                        //if the last spot in the array has something in it, it means that the buffer is full and the tread should therefore wait.
                        if (counter[counter.Length - 1] != null)
                        {
                            Console.WriteLine("Counter[{0}] is full and waiting to be emptied...", Thread.CurrentThread.ManagedThreadId);
                            Monitor.Wait(counter);
                        }
                        int x = 0;
                        foreach (string item in counter)
                        {
                            if (counter[x] != null)
                            {
                                x++;
                            }
                        }
                        counter[x] = "To terminal#" + r.Next(1, 4).ToString();
                        Console.WriteLine("Counter[{2}] added baggage[{0}] -- Buffer capacity {1}/5", counter[x], x + 1, Thread.CurrentThread.ManagedThreadId);
                    }
            }
        }

        //terminals to be collected at random intervals simlulating planes taking off.
        static void Terminal(object arg)
        {
            if (terminal1[19] != null)
            {
                lock (terminal1)
                {
                    Console.WriteLine("Plane at terminal[1] is taking off! nnneeaoowww");
                    terminal1 = new string[20];
                    Console.WriteLine("Terminal[1] buffer capacity 0/{0}", terminal1.Length);
                    Monitor.PulseAll(terminal1);
                }
            }
            if (terminal2[19] != null)
            {
                lock (terminal2)
                {
                    Console.WriteLine("Plane at terminal[2] is taking off! nnneeaoowww");
                    terminal2 = new string[20];
                    Console.WriteLine("Terminal[2] buffer capacity 0/{0}", terminal2.Length);
                    Monitor.PulseAll(terminal2);
                }
            }
            if (terminal3[19] != null)
            {
                lock (terminal3)
                {
                    Console.WriteLine("Plane at terminal[3] is taking off! nnneeaoowww");
                    terminal3 = new string[20];
                    Console.WriteLine("Terminal[3] buffer capacity 0/{0}", terminal1.Length);
                    Monitor.PulseAll(terminal3);
                }
            }

        }

        //send values to terminals
        static void Sorter(object arg)
        {
            while (true)
            {
                lock (sorter1)
                {
                    Thread.Sleep(500);
                    while (sorter1.Count == 0)
                    {
                        Monitor.Wait(sorter1);
                        Console.WriteLine("There is nothing to sort, waiting for baggage...", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(10000);
                    }
                    Thread.Sleep(500);

                    if (sorter1.Peek() == "To terminal#1")
                    {

                        lock (terminal1)
                        {
                            if (terminal1[19] != null)
                            {
                                Monitor.Wait(terminal1);
                            }
                            int x = 0;
                            foreach (string item in terminal1)
                            {
                                if (terminal1[x] != null)
                                {
                                    x++;
                                }
                            }
                            terminal1[x] = sorter1.Dequeue();
                            Console.WriteLine("Terminal[1] moved baggage[{0}] to terminal#1 -- Buffer capacity {1}/20", terminal1[x], x + 1);

                            Monitor.PulseAll(terminal1);
                        }
                    }
                    else if (sorter1.Peek() == "To terminal#2")
                    {
                        Thread.Sleep(500);

                        lock (terminal2)
                        {
                            if (terminal1[19] != null)
                            {
                                Monitor.Wait(terminal2);
                            }
                            int x = 0;
                            foreach (string item in terminal2)
                            {
                                if (terminal2[x] != null)
                                {
                                    x++;
                                }
                            }
                            terminal2[x] = sorter1.Dequeue();
                            Console.WriteLine("Terminal[2] moved baggage[{0}] to terminal#2 -- Buffer capacity {1}/20", terminal2[x], x + 1);

                            Monitor.PulseAll(terminal2);
                        }
                    }

                    else if (sorter1.Peek() == "To terminal#3")
                    {
                        Thread.Sleep(500);
                        lock (terminal3)
                        {
                            if (terminal3[19] != null)
                            {
                                Monitor.Wait(terminal1);
                            }
                            int x = 0;
                            foreach (string item in terminal3)
                            {
                                if (terminal3[x] != null)
                                {
                                    x++;
                                }
                            }
                            terminal3[x] = sorter1.Dequeue();
                            Console.WriteLine("Terminal[3] moved baggage[{0}] to terminal#3 -- Buffer capacity {1}/20", terminal3[x], x + 1);

                            Monitor.PulseAll(terminal3);
                        }
                    }
                    else
                    {
                        //debugging
                        while (true)
                        {
                            Console.WriteLine("error");
                        }
                    }
                }
            }
        }



        //collects the baggage from the counters
        static void CounterCollecter()
        {
            while (true)
            {
                while (sorter1.Count >= 85)
                {
                    Console.WriteLine("Sorter queue near maximum capacity {0}/100 Baggage collecting paused...", sorter1.Count);
                    Thread.Sleep(10000);
                }
                Thread.Sleep(15000);
                //Hvis der er en værdi på den førse plads i arrayed, så ved sorteren at der er bagagge som den kan collecte.
                if (counter1[0] != null)
                {
                    lock (counter1)
                    {
                        Empty(counter1);
                        Monitor.PulseAll(counter1);
                    }
                }
                Thread.Sleep(5000);
                if (counter2[0] != null)
                {
                    lock (counter2)
                    {
                        Empty(counter2);
                        Monitor.PulseAll(counter2);
                    }
                }
                Thread.Sleep(5000);
                if (counter3[0] != null)
                {
                    lock (counter3)
                    {
                        Empty(counter3);
                        Monitor.PulseAll(counter3);
                    }
                }
                Thread.Sleep(5000);

            }
        }

        //Empties the counter arrays and puts it all into the sorting queue.
        static void Empty(string[] counter)
        {
            int x = 0;
            foreach (string item in counter)
            {
                string tempBaggage = counter[x];
                counter[x] = null;

                if (tempBaggage != null)
                {
                    lock (sorter1)
                    {
                        sorter1.Enqueue(tempBaggage);
                        Console.WriteLine("Baggage[{0}] moved to the sorting queue -- Buffer capacity {1}/100", tempBaggage, sorter1.Count);
                        Monitor.PulseAll(sorter1);
                    }
                }
                x++;

            }
        }


    }
}
