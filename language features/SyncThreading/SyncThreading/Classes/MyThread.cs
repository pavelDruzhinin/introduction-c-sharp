using System;
using System.Threading;

namespace SyncThreading.Classes
{
    class MyThread
    {
        public Thread Thrd;
        readonly int[] a;
        int answer;

        static readonly SumArray sa = new SumArray();

        public MyThread(string name, int[] nums)
        {
            a = nums;
            Thrd = new Thread(this.Run) {Name = name};
            Thrd.Start();
        }

        void Run()
        {
            Console.WriteLine(Thrd.Name + " начат.");
            answer = sa.SumIt(a);
            Console.WriteLine("Сумма для потока " + Thrd.Name + " равна " + answer);
            Console.WriteLine(Thrd.Name + " завершен.");
        }
    }
}
