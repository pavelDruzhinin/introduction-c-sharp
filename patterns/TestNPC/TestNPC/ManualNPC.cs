using System.ComponentModel;

namespace TestNPC
{
    public sealed class ManualNPC : INotifyPropertyChanged
    {
        private void RaisePropertyChanged(string propName)
        {
            var e = PropertyChanged;
            if (e != null)
                e(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region MyProperty Property

        private string _myProperty;

        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                if (_myProperty == value) return;
                var oldValue = _myProperty;
                _myProperty = value;
                DoSomething(oldValue, value);
                RaisePropertyChanged("MyProperty");
            }
        }

        private void DoSomething(string oldValue, string value)
        {
            Count++;
        }

        #endregion

        #region MyProperty2 Property

        private string _myProperty2;

        public string MyProperty2
        {
            get { return _myProperty2; }
            set
            {
                if (_myProperty2 == value) return;
                _myProperty2 = value;
                RaisePropertyChanged("MyProperty2");
            }
        }


        #endregion

        public int Count { get; set; }
    }
}