using System;
using System.Threading;
using System.Diagnostics;

namespace ThreadPools
{
    class Program
    {
        public void task1(object obj)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 1 is being executed");
            }
        }
        public void task2(object obj)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 2 is being executed");
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void Process(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {

                }
            }
        }

        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");

            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());

            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());

            Program tpd = new Program();
            for (int i = 0; i < 2; i++)
            {
                ThreadPool.QueueUserWorkItem(tpd.task1);
                ThreadPool.QueueUserWorkItem(tpd.task2);
            }

            Console.Read();
        }
    }
}
