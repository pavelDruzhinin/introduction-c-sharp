using System;
using UseVirtMeth;

namespace MyProg
{
    class Program
    {
        static void Main()
        {
            var shapes = new[]
            {
                new Triangle(8, 10, "прямоугольныый"),
                new Rectangle(10),
                new Rectangle(4, 10),
                new Triangle(7.0),
                new TwoDShape(10, 20, "общая форма")
            };

            foreach (var shape in shapes)
            {
                shape.Show();
                Console.WriteLine("Площадь = " + shape.Area());
                Console.WriteLine();
            }
            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}