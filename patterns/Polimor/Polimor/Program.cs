using System;

namespace Polimor
{
    class Program
    {
        static void Main()
        {
            //   MyBase ob1 = new MyBase(1);
            //  MyBase ob2 = new MyDerived(2,3);
            var obAr = new[] { new MyBase(1), new MyDerived(2, 3) };
            GenFun(obAr[0], 8);
            GenFun(obAr[1], 9);
            Console.ReadLine();

        }
        static void GenFun(MyBase ob, int val)
        {
            ob.Set(val);
            ob.Print();
        }
    }
}
