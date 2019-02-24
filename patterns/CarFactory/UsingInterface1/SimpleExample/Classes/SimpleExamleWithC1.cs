using System;
using System.Collections.Generic;
using UsingInterface1.Interface;

namespace UsingInterface1.Classes
{
    class SimpleExamleWithC1
    {
        public void FillList()
        {
            var myList = new List<I1>();

            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                if (rand.Next(100) < 50) myList.Add(new C1());
                else myList.Add(new C2());
            }

            foreach (var item in myList)
            {
                item.doit();
            }
        }
    }
}
