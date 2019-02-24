using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestMVVM.Annotations;

namespace TestMVVM.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public string DisplayName { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
