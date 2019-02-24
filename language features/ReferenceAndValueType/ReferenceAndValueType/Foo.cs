namespace ReferenceAndValueType
{
    class Foo
    {
        
            public int Sum(int x, int y)
            {
                var z = x + y;
                x = 17;
                return z;
            }

            public int Sum(ref int x, ref int y)
            {
                var z = x + y;
                x = 17;
                return z;
            }
        
    }
}
