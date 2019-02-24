using System;
using System.Threading;

namespace TickTockThreading.Classes
{
    class TickTock
    {
        readonly object lockon = new object();
        public void Tick(bool running)
        {
            lock (lockon)
            {
                if (!running)
                {
                    Monitor.Pulse(lockon);
                    return;
                }
                Console.Write("тик ");
                Monitor.Pulse(lockon);
                Monitor.Wait(lockon);
            }
        }

        public void Tock(bool running)
        {
            lock (lockon)
            {
                if (!running)
                {
                    Monitor.Pulse(lockon);
                    return;
                }
                Console.WriteLine("так");
                Monitor.Pulse(lockon);
                Monitor.Wait(lockon);
            }
        }
    }
}
