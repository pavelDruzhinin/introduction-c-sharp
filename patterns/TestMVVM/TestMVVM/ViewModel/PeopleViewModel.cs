using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TestMVVM.Helpers;
using TestMVVM.Model;

namespace TestMVVM.ViewModel
{
    public class PeopleViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Person> people;
        public Person currentPerson;

        public PeopleViewModel()
        {
            people = new ObservableCollection<Person>
            {
                new Person { Age = 23, FirstName = "Иван", LastName = "Иванов" },
                new Person { Age = 22, FirstName = "Петр", LastName = "Петров" },
                new Person { Age = 42, FirstName = "Сидор", LastName = "Сидоров" },
                new Person { Age = 36, FirstName = "Сергей", LastName = "Сергеев" },
                new Person { Age = 3, FirstName = "Анатолий", LastName = "Попов" }
            };

            foreach (var person in People)
            {
                var girls = new List<BaseItem>
                {
                    new BaseItem{Id=1,Name = "Даша"},
                    new BaseItem{Id=2,Name = "Маша"},
                    new BaseItem{Id=3,Name = "Катя"},
                };

                person.Girls = new ObservableCollection<BaseItem>(girls);
                person.Girl = person.Girls[0];
            }
        }

        public Person SelectedPerson
        {
            get
            {
                return currentPerson;
            }
            set
            {
                if (currentPerson == value)
                    return;

                currentPerson = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Person> People
        {
            get { return people; }
        }

        private RelayCommand _decreaseCommand;
        public ICommand DecreaseCommand
        {
            get { return _decreaseCommand ?? (_decreaseCommand = new RelayCommand(x => this.decrease())); }
        }

        private RelayCommand _increaseCommand;

        public ICommand IncreaseCommand
        {
            get { return _increaseCommand ?? (_increaseCommand = new RelayCommand(x => this.increase())); }
        }

        private void decrease()
        {
            if (currentPerson == null)
                return;

            currentPerson.Age--;
        }

        private void increase()
        {
            if (currentPerson == null)
                return;

            currentPerson.Age++;
        }
    }
}