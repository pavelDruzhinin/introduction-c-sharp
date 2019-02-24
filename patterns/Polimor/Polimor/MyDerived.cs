using System;

namespace Polimor
{
    class MyDerived : MyBase
    {
        private int X2;
        public MyDerived(int x, int y)
            : base(x)
        {
            X2 = y;
        }
        public void Set(int x, int y)
        {
            X1 = x;
            X2 = y;
        }
        public override void Print()
        {
            Console.WriteLine("X1 = {0} X2 = {1}", X1, X2);
        }
    }
}