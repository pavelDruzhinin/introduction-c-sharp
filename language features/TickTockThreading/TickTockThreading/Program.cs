using System;
using TickTockThreading.Classes;

namespace TickTockThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            var tt = new TickTock();
            var mt1 = new MyThread("Tick",tt);
            var mt2 = new MyThread("Tock",tt);

            mt1.Thrd.Join();
            mt2.Thrd.Join();

            Console.WriteLine("Часы остановлены.");
        }
    }
}
