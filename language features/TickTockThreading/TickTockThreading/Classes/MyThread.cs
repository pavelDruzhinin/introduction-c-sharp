using System.Threading;

namespace TickTockThreading.Classes
{
    class MyThread
    {
        public Thread Thrd;
        readonly TickTock ttOb;

        public MyThread(string name, TickTock tt)
        {
            Thrd = new Thread(this.Run);
            ttOb = tt;
            Thrd.Name = name;
            Thrd.Start();
        }

        void Run()
        {
            if (Thrd.Name == "Tick")
            {
                for (var i = 0; i < 5; i++)
                {
                    ttOb.Tick(true);
                }
                ttOb.Tick(false);
            }
            else
            {
                for (var i = 0; i < 5; i++)
                {
                    ttOb.Tock(true);
                }
                ttOb.Tock(false);
            }
        }
    }
}
