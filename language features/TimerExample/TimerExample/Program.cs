using System;
using System.Threading;

namespace TimerExample
{
    class Program
    {
        static void Main()
        {
            // Create an event to signal the timeout count threshold in the
            // timer callback.
            var autoEvent = new AutoResetEvent(false);

            var statusChecker = new StatusChecker(10);

            // Create an inferred delegate that invokes methods for the timer.
            TimerCallback tcb = statusChecker.CheckStatus;

            // Create a timer that signals the delegate to invoke 
            // CheckStatus after one second, and every 1/4 second 
            // thereafter.
            Console.WriteLine("{0} Creating timer.\n",
                DateTime.Now.ToString("h:mm:ss.fff"));
            var stateTimer = new Timer(tcb, autoEvent, 1000, 250);

            // When autoEvent signals, change the period to every
            // 1/2 second.
            autoEvent.WaitOne(50000, false);
            stateTimer.Change(0, 1000);
            Console.WriteLine("\nChanging period.\n");

            // When autoEvent signals the second time, dispose of 
            // the timer.
            autoEvent.WaitOne(10000, false);
            stateTimer.Dispose();
            Console.WriteLine("\nDestroying timer.");
        }
    }


}