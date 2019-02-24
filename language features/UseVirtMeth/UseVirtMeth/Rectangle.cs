using System;

namespace UseVirtMeth
{
    class Rectangle : TwoDShape
    {
        public Rectangle(double h, double w) : base(w, h, "прямоугольник") { }
        public Rectangle(double x) : base(x, "квадрат") { }
        public Rectangle(Rectangle ob) : base(ob) { }
        public bool IsSquare()
        {
            if (Width == Height)
                return true;
            return false;
        }
        public override double Area()
        {
            return Width * Height;
        }
        new public void Show()
        {
            base.Show();
        }
    }
}
