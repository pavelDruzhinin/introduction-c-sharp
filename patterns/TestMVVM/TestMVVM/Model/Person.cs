using System.Collections.ObjectModel;
using TestMVVM.ViewModel;

namespace TestMVVM.Model
{
    public class Person : ViewModelBase
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private BaseItem _girl;
        private ObservableCollection<BaseItem> _girls;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(); }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public BaseItem Girl
        {
            get { return _girl; }
            set { _girl = value; OnPropertyChanged(); }
        }

        public ObservableCollection<BaseItem> Girls
        {
            get { return _girls; }
            set { _girls = value; OnPropertyChanged(); }
        }
    }
}