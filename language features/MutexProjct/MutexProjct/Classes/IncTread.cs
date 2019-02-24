using System;
using System.Threading;

namespace MutexProject.Classes
{
    public class IncThread
    {
        int num;
        public Thread Thrd;

        public IncThread(string name, int n)
        {
            Thrd = new Thread(this.Run) {Name = name};
            num = n;
            Thrd.Start();
        }

        void Run()
        {
            Console.WriteLine(Thrd.Name + " ожидает мьютекс.");

            SharedRes.Mtx.WaitOne();

            Console.WriteLine(Thrd.Name + " получает мьютекс.");

            do
            {
                Thread.Sleep(500);
                SharedRes.Count++;
                Console.WriteLine("В потоке {0} Shared.Count = {1}", Thrd.Name, SharedRes.Count);
                num--;
            } while (num > 0);
            Console.WriteLine(Thrd.Name +" освобождает поток.");
            SharedRes.Mtx.ReleaseMutex();
        }
    }
}
