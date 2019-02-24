using System;
using EventConsoleApplication.Classes.Contracts;

namespace EventConsoleApplication.Classes
{
    public class Cat : Animal, ICat
    {
        private readonly string _name;
        public string Name { get { return _name; } }

        public Cat(string name)
        {
            _name = name;
            base._ears = 2;
            base._paws = 4;
        }

        public void Crap()
        {
            var args = new CatArgs { Message = _name + ": Crap", Date = DateTime.Now };
            OnCrap(args);
        }

        public void Piss()
        {
            var args = new CatArgs { Message = _name + ": Piss", Date = DateTime.Now };
            OnPiss(args);
        }

        public void Eat()
        {
            var args = new CatArgs { Message = _name + ": Eat", Date = DateTime.Now };
            OnEat(args);
        }


        #region Events

        protected virtual void OnCrap(CatArgs e)
        {
            var handler = CrapEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPiss(CatArgs e)
        {
            var handler = PissEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnEat(CatArgs e)
        {
            var handler = EatEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<CatArgs> CrapEvent;
        public event EventHandler<CatArgs> PissEvent;
        public event EventHandler<CatArgs> EatEvent;

        #endregion

    }
}