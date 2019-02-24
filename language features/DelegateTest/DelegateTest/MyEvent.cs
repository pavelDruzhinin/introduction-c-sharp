namespace DelegateTest
{
    public class MyEvent
    {
        public delegate void MyEventHandler();

        public event MyEventHandler SomeEvent;

        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                SomeEvent();
        }
    }
}