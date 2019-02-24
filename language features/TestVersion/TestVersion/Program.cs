using System;

namespace TestVersion
{
    class Program
    {
        static void Main()
        {
            var objVersion = new Software();
            var version = objVersion.GetSoftwateVersion("ЧекАлко");
            Console.WriteLine(version);
            Console.ReadLine();

        }
    }
}
