using MutexProject.Classes;
using System.Threading;

namespace MutexProject
{
    class Program
    {
        static void Main()
        {
            var mt1 = new IncThread("Инкрементирующий", 5);

            Thread.Sleep(1);

            var mt2 = new DecThread("Декрементирующий", 3);

            mt1.Thrd.Join();

            mt2.Thrd.Join();
        }
    }
}
