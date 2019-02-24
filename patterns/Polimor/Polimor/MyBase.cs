using System;

namespace Polimor
{
    class MyBase
    {
        protected int X1;
        public MyBase(int x)
        {
            X1 = x;
            Console.WriteLine("Первое значение X1= {0}", X1);
        }
        public void Set(int x)
        {
            X1 = x;
        }
        public virtual void Print()
        {
            Console.WriteLine("X1 = {0}", X1);
        }
    }
}