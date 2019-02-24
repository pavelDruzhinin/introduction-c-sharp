using SyncThreading.Classes;

namespace SyncThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            var mt1 = new MyThread("Поток 1", a);
            var mt2 = new MyThread("Поток 2", a);

            mt1.Thrd.Join();

            mt2.Thrd.Join();
        }
    }
}
