using System;
using System.Threading;

namespace SyncThreading.Classes
{
    class SumArray
    {
        int sum;
        readonly object lockOn = new object();

        public int SumIt(int[] nums)
        {
            lock (lockOn)
            {
                sum = 0;
                foreach (var num in nums)
                {
                    sum += num;
                    Console.WriteLine("Текущая сумма для потока " + Thread.CurrentThread.Name + " равна " + sum);
                    Thread.Sleep(10);
                }
                return sum;
            }
        }
    }
}
