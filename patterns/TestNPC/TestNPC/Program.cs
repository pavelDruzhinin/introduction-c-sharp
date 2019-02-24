using System;

namespace TestNPC
{
    internal class Program
    {
        private static void Main()
        {
            Test.RunManualNPC();
            Test.RunMagicNPC();
            Test.RunLambdaNPC();
            Test.RunStackTraceNPC();

            Console.WriteLine();
            Console.WriteLine("That's all folks");
            Console.ReadLine();
        }
    }
}

