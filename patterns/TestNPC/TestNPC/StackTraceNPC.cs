using System.ComponentModel;
using System.Diagnostics;

namespace TestNPC
{
    public sealed class StackTraceNPC : INotifyPropertyChanged
    {
        public int Count { get; set; }

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
                RaisePropertyChanged();
            }
        }

        #endregion

        #region MyProperty2 Property

        private string _myProperty2;

        public string MyProperty2
        {
            get { return _myProperty2; }
            set
            {
                if (_myProperty == value) return;
                _myProperty2 = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        private void DoSomething(string oldValue, string newValue)
        {
            Count++;
        }

        private void RaisePropertyChanged()
        {
            RaisePropertyChanged(new StackTrace().GetFrame(1).GetMethod().Name.Substring(4));
        }

        private void RaisePropertyChanged(string propName)
        {
            var e = PropertyChanged;
            if (e != null)
                e(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}