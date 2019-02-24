namespace DelegateTest
{
    public class Value
    {
        private string value;

        public Value()
        {
            value = "8";
        }

        public string Get()
        {
            return value;
        }

        public void Set(string v)
        {
            value = v;
        }
    }
}