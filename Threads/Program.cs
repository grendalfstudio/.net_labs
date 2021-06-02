using System;
using System.Diagnostics;

namespace Threads
{
    class Program
    {
        static void Main(string[] args)
        {
            SumCounter counter = new SumCounter();
            FileReader reader = new FileReader(@".\text.txt");
            Stopwatch stopwatch;
            
            /*Console.WriteLine("Task 4.1:");
            Console.WriteLine("Without threads:");
            stopwatch = Stopwatch.StartNew();
            counter.DoTask();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);*/
            
            /*Console.WriteLine("With threads:");
            stopwatch = Stopwatch.StartNew();
            counter.DoTaskWithThreads();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);*/
            
            Console.WriteLine("Task 4.2 - 4.4:");
            //reader.DoTask1();
            //reader.DoTask2();
            //reader.DoTask3();
            //reader.DoTask4();
        }
    }
}