using System;

namespace DelegateTest.Virtual
{
    public class A
    {
        public virtual void Do()
        {
            Console.WriteLine("A");
        }
    }

    public class B : A
    {
        //if instead of override define new, then run Do from A :)
        public new void Do()
        {
            Console.WriteLine("B");
        }
    }
}