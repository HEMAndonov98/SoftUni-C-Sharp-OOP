using System;
namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.width + this.height);
        }

        public override string Draw()
        {
            return base.Draw() +
                nameof(Rectangle);
        }
    }
}

