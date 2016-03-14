using System.Linq;

namespace OpenClosedPrinciple.Improved
{
    public class GraphicEditor
    {
        private readonly IDrawStrategy[] _drawStrategies;

        public GraphicEditor(IDrawStrategy[] drawStrategies)
        {
            _drawStrategies = drawStrategies;
        }

        public void DrawShape(Shape shape)
        {
            var strategy = _drawStrategies.Single(s => s.CanHandle(shape.Type));
            strategy.Draw(shape);
        }
    }

    public interface IDrawStrategy
    {
        bool CanHandle(ShapeTypes type);
        void Draw(Shape shape);
    }

    public class DrawCircleStrategy : IDrawStrategy
    {
        public bool CanHandle(ShapeTypes type)
        {
            return type == ShapeTypes.Circle;
        }

        public void Draw(Shape shape)
        {
            // draw the circle
            throw new System.NotImplementedException();
        }
    }

    public class DrawRectangleStrategy : IDrawStrategy
    {
        public bool CanHandle(ShapeTypes type)
        {
            return type == ShapeTypes.Rectangle;
        }

        public void Draw(Shape shape)
        {
            // draw the rectangle
            throw new System.NotImplementedException();
        }
    }
}