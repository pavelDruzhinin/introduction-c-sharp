using System.ComponentModel;

namespace TestNPC
{
    [Magic]
    public sealed class MagicNPC : INotifyPropertyChanged
    {
        private void RaisePropertyChanged(string propName)
        {
            var e = PropertyChanged;
            if (e != null)
                e(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _myProperty;

        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                var oldValue = _myProperty;
                _myProperty = value;
                DoSomething(oldValue, value);
            }
        }

        public string MyProperty2 { get; set; }

        private void DoSomething(string oldValue, string value)
        {
            Count++;
        }

        public int Count { get; set; }
    }
}