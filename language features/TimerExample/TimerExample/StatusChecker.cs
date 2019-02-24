using System;
using System.Threading;

namespace TimerExample
{
    public class StatusChecker
    {
        private int invokeCount;
        private readonly int maxCount;

        public StatusChecker(int count)
        {
            invokeCount = 0;
            maxCount = count;
        }

        // This method is called by the timer delegate.
        public void CheckStatus(Object stateInfo)
        {
            var autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0} Checking status {1,2}.",
                DateTime.Now.ToString("h:mm:ss.fff"),
                (++invokeCount));

            if (invokeCount != maxCount)
                return;

            // Reset the counter and signal Main.
            invokeCount = 0;
            autoEvent.Set();
        }
    }

}
