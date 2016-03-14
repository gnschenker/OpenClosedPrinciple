namespace OpenClosedPrinciple.Improved
{
    public class AreaCalculator
    {
        public double Area(Shape[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.GetArea();
            }
            return area;
        }
    }
}