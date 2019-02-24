using System;

namespace UseVirtMeth
{
    class TwoDShape
    {
        double pri_width;
        double pri_height;

        public double Width
        {
            get { return pri_width; }
            set { pri_width = value > 0 ? value : -value; }
        }

        public string name { get; set; }
        public double Height
        {
            get { return pri_height; }
            set { pri_height = value > 0 ? value : -value; }
        }
        public TwoDShape()
        {
            Height = Width = 0.0;
            name = "null";
        }
        public TwoDShape(double h, double w, string s)
        {
            Width = w;
            Height = h;
            name = s;
        }
        public TwoDShape(double x, string n)
        {
            Width = Height = x;
            name = n;
        }
        public TwoDShape(TwoDShape ob)
        {
            Width = ob.Width;
            Height = ob.Height;
            name = ob.name;
        }
        public void Show()
        {
            Console.WriteLine("Информация о данном объекте");
            Console.WriteLine("Объект - {0}",name);
            Console.WriteLine("Ширина = {0}, Высота = {1}",Height,Width);
        }
        public virtual double Area()
        {
            Console.WriteLine("Метод Area() должен быть переопределен");
            return 0.0;
        }
    }
}
