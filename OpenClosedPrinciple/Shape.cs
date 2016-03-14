namespace OpenClosedPrinciple
{
    public abstract class Shape
    {
        public ShapeTypes Type { get; set; }
    }

    public enum ShapeTypes
    {
        Rectangle = 1,
        Circle = 2
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
}