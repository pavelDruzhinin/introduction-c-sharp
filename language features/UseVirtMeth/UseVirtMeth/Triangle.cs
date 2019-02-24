using System;

namespace UseVirtMeth
{
    class Triangle: TwoDShape
    {
        string Style;

        public Triangle()
        {
            Style = "null";
        }
        public Triangle(double h, double w, string s)
            : base(h, w, "треугольник")
        {
            Style = s;
        }
        public Triangle(double x)
            : base(x, "треугольник")
        {
            Style = "pавнобедренный";
        }
        public Triangle(Triangle ob)
            : base(ob)
        {
            Style = ob.Style;
        }
        public override double Area()
        {
            return Height * Width / 2;
        }
        new public void Show()
        {
            base.Show();
            Console.WriteLine("{0} {1}",name,Style);
        }
    }
}
