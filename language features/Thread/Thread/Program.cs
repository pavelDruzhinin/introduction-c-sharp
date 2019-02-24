using System;
using System.Threading;
using ThreadExample.Classes;

namespace ThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Основной поток начат.");

            const string name1 = "Потомок №1";
            const string name2 = "Потомок №2";
            const string name3 = "Потомок №3";

            var mt1 = new MyThread(name1);
            var mt2 = new MyThread(name2);
            var mt3 = new MyThread(name3);

            mt1.Thrd.Priority = ThreadPriority.BelowNormal;
            mt2.Thrd.Priority = ThreadPriority.Highest;
            mt3.Thrd.Priority = ThreadPriority.Normal;

            mt1.Thrd.Start();
            mt2.Thrd.Start();
            mt3.Thrd.Start();

            mt1.Thrd.Join();
            Console.WriteLine(name1 + " присоединен.");

            mt2.Thrd.Join();
            Console.WriteLine(name2 + " присоединен.");

            mt3.Thrd.Join();
            Console.WriteLine(name3 + " присоединен.");

            Console.WriteLine();
            Console.WriteLine("Поток " + mt1.Thrd.Name + " досчитал до " + mt1.Count);
            Console.WriteLine("Поток " + mt2.Thrd.Name + " досчитал до " + mt2.Count);
            Console.WriteLine("Поток " + mt3.Thrd.Name + " досчитал до " + mt3.Count);
        }
    }
}
