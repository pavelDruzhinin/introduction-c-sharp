using System;
using System.Data.SqlTypes;
using System.Threading;
using DelegateTest.Virtual;

namespace DelegateTest
{
    class Program
    {

        private delegate void StrMod(ref string str);
        private delegate X ChangeIt(Y obj);
        private delegate void CountIt(int end);
        private delegate string Get();

        private delegate int AsyncDel(string text);


        static void Main()
        {

            ShowResult(new StrMod(ManageString.ReplaceSpaces)
                + ManageString.RemoveSpaces
                + ManageString.Reverse);


            ShowCoCoVarience();

            AnonimMethod();

            var evt = new MyEvent();

            evt.SomeEvent += Handler;

            evt.OnSomeEvent();

            Message();

            ShowValue();
            ShowStruct();
            ShowVirtual();

            ShowAsync();

        }

        #region Show group delegate

        static void ShowResult(StrMod modifier)
        {
            var testText = "Это просто текст";

            modifier(ref testText);

            Message(testText);
            Message();
        }

        #endregion

        #region Show CoCoVarience

        static void ShowCoCoVarience()
        {
            var Yob = new Y();

            // В данном случае параметром метода IncrA является объект класса X,
            // а параметром делегата ChangeIt — объект класса Y. Но благодаря
            // контравариантности следующая строка кода вполне допустима.
            ChangeIt change = CoContraVariance.IncA;

            var Xob = change(Yob);

            Console.WriteLine("Xob: " + Xob.Val);

            // В этом случае возвращаемым типом метода IncrB служит объект класса Y,
            // а возвращаемым типом делегата ChangeIt — объект класса X. Но благодаря
            // ковариантности следующая строка кода оказывается вполне допустимой.
            change = CoContraVariance.IncB;

            Yob = (Y)change(Yob);
            Message("Yob: " + Yob.Val);
            Message();
        }

        #endregion

        #region Anonim Method

        static void AnonimMethod()
        {
            // Далее следует код для подсчета чисел, передаваемый делегату
            // в качестве анонимного метода.
            CountIt count = delegate(int end)
            {
                // Этот кодовый блок передается делегату.
                for (var i = 0; i <= end; i++)
                    Message(i + "");
                Message();
            }; // обратите внимание на точку с запятой

            count(3);
            count(2);

            Message();
        }

        #endregion

        #region Show value

        static void ShowValue()
        {
            var value = new Value();
            Get get = value.Get;

            Message("Value before:" + get());

            value.Set("5");

            Message("Value after:" + get());

            Message();
        }

        #endregion

        #region Show Async

        private static void ShowAsync()
        {
            AsyncDel counter = AsyncDelegate.CountCharacters;
            AsyncDel parser = AsyncDelegate.Parse;

            var counterResult = counter.BeginInvoke("hello", null, null);
            var parserResult = parser.BeginInvoke("10", null, null);

            Message("Основной поток с ID = " + Thread.CurrentThread.ManagedThreadId + " продолжает выполняться");

            Message();
            Message("Счётчик вернул " + counter.EndInvoke(counterResult));
            Message("Парсер вернул " + parser.EndInvoke(parserResult));
            Message();

            Message("Основной поток с  ID = " + Thread.CurrentThread.ManagedThreadId + " завершился");
            Message();

        }


        #endregion


        #region Events

        static void Handler()
        {
            Message("Произошло событие");
        }


        #endregion

        #region Message

        static void Message(string text = null)
        {
            var d = DateTime.Now;

            if (String.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine();
                return;
            }

            Console.WriteLine("[{0}]:{1}", d.ToString("MM.dd.yyyy HH:mm:ss"), text);
        }


        #endregion

        #region Show Struct

        static void ShowStruct()
        {
            Subscruber s1;
            Subscruber s2;

            s1 = new Subscruber();

            s1.SubId = 1;
            s1.Name = "Xel";
            s1.LastName = "Roq";
            s1.Balance = 40;

            Message("s1.Balance before copy :" + s1.Balance);

            s2 = s1;

            s2.Balance = 50;
            Message("s1.Balance after copy :" + s1.Balance);
            Message("s2.Balance after copy :" + s2.Balance);
            Message();
        }


        #endregion

        #region Show Virtual

        static void ShowVirtual()
        {
            var b = new B();
            A a = b;

            a.Do();

            Message();
        }


        #endregion
    }
}
