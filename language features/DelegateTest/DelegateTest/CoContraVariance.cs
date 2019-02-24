namespace DelegateTest
{
    public class X
    {
        public int Val;
    }

    public class Y : X
    {
        
    }

    public class CoContraVariance
    {
        public static X IncA(X obj)
        {
            var temp = new X();
            temp.Val += 1;
            return temp;
        }

        public static Y IncB(Y obj)
        {
            var temp = new Y();
            temp.Val += 1;
            return temp;
        }
    }
}