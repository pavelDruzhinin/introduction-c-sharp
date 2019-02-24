using System;
using System.Threading;

namespace ThreadExample.Classes
{
    class MyThread
    {
        public int Count;
        public Thread Thrd;

        static bool stop;
        static string currentName;

        public MyThread(string name)
        {
            Count = 0;
            Thrd = new Thread(this.Run) {Name = name};
            currentName = name;
        }

        public void Run()
        {
            Console.WriteLine("Поток " + Thrd.Name + " начат.");

            do
            {
                Count++;
                if (currentName == Thrd.Name) 
                    continue;

                currentName = Thrd.Name;
                Console.WriteLine("В потоке " + currentName);
            } while (stop == false && Count < 1000000000);
            stop = true;
            Console.WriteLine("Поток " + Thrd.Name + " завершен.");
        }
    }
}
