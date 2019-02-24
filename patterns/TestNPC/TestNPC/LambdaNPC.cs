using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace TestNPC
{
    public sealed class LambdaNPC : INotifyPropertyChanged
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
                RaisePropertyChanged(i => i.MyProperty);
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
                if (_myProperty2 == value) return;
                _myProperty2 = value;
                RaisePropertyChanged(i => i.MyProperty2);
            }
        }

        #endregion

        private void DoSomething(string oldValue, string newValue)
        {
            Count++;
        }

        private void RaisePropertyChanged<T>(Expression<Func<LambdaNPC, T>> raiser)
        {
            RaisePropertyChanged(((MemberExpression)raiser.Body).Member.Name);
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