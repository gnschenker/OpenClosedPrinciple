namespace OpenClosedPrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var sorter = new Sorter();
            var result = sorter.Sort(new[] {3, 2, 4, 5, 4, 3, 7, 6, 9});

            var shapes = new Shape[]
            {
                new Circle {Radius = 11}, 
                new Rectangle {Height = 10, Width = 15}, 
            };
            var totalArea = new AreaCalculator().Area(shapes);
        }
    }
}
