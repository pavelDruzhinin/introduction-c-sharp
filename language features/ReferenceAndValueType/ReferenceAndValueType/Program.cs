
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceAndValueType
{
    class Program
    {
        static void Main(string[] args)
        {

            var firtsNumber = 10;
            var secondNumber = 20;
            var foo = new Foo();

            // вот тут мы вызываем метод который будет работат с типами значения так, как они работаю обычно.
            // Т.е. когда вы сохздаете метод с параметрами value type, метод будет автоматически копировать значения которые
            // вы подадите ему на вход и уже работать с их копиями, которые сразу же исчезнут при отработке метода
            // есть способ избежать этого, работая с value type как с reference type, передавая не копии переменных, а
            // ссылки на них в памяти.
            // После того как этот метод отработает копия переменной firstNumber исчезнет и само значение firstNumber не
            // изменится
            Console.WriteLine(foo.Sum(firtsNumber, secondNumber));

            //Вот тут мы вызываем другой метод, в который уже подаем параметры по ссылке на них,
            // Т.е. этот метод будет работать с оригиналом переменных, а значит при его отработке переменная firstNumber изменится
            // и будет равна 17
            Console.WriteLine(foo.Sum(ref firtsNumber, ref secondNumber));

            Console.WriteLine(firtsNumber);
        }
    }
}
