using System;
using System.Diagnostics;
using System.Threading;

namespace Threads
{
    public class SumCounter
    {
        public void DoTask()
        {
            for (int i = 0; i < 3; i++)
            {
                CountSum();
            }
        }

        public void DoTaskWithThreads()
        {
            Thread thread1 = new Thread(CountSum);
            Thread thread2 = new Thread(CountSum);
            
            CountSum();
            thread1.Start();
            thread2.Start();
        }
        
        private void CountSum()
        {
            var sum = 0;
            for (var i = 1; i <= 100000000; i++) 
            { 
                sum += i;
            }
            Console.WriteLine("Sum= " + sum);
        }
    }
}