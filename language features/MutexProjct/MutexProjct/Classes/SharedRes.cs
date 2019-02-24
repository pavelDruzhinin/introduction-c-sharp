using System.Threading;

namespace MutexProject.Classes
{
    class SharedRes
    {
        public static int Count = 0;
        public static Mutex Mtx = new Mutex();
    }
}
