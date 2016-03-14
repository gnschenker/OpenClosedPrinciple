using System;

namespace OpenClosedPrinciple
{
    // this class violates the open-close principle since whenever I add a new
    // shape I have to modify this class.
    public class AreaCalculator {
        public double Area(Shape[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                if (shape.Type == ShapeTypes.Rectangle)
                {
                    var rectangle = (Rectangle) shape;
                    area += rectangle.Width*rectangle.Height;
                }
                else
                {
                    var circle = (Circle) shape;
                    area += circle.Radius*circle.Radius*Math.PI;
                }
            }

            return area;
        }
    }
}