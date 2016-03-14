using System;

namespace OpenClosedPrinciple.Improved
{
    public abstract class Shape
    {
        public ShapeTypes Type { get; set; }
        public abstract double GetArea();
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return 2 * Radius * Math.PI;
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public override double GetArea()
        {
            return Width * Height;
        }
    }
}