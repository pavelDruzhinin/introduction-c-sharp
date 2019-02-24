using System;
using UsingInterface1.Interface;

namespace UsingInterface1.Classes
{
    class C1 : I1
    {
        public void doit()
        {
            Console.WriteLine("Класс 1");
        }
    }

    class C2 : I1
    {
        public void doit()
        {
            Console.WriteLine("Класс 2");
        }
    }
}
