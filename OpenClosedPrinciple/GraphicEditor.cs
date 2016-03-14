namespace OpenClosedPrinciple
{
    // this class also violates the open-close principle
    // each time a new shape is added I have to exend this class
    public class GraphicEditor
    {
        public void DrawShape(Shape s)
        {
            if (s.Type == ShapeTypes.Rectangle)
                DrawRectangle((Rectangle)s);
            else if (s.Type == ShapeTypes.Circle)
                DrawCircle((Circle)s);
        }
        public void DrawCircle(Circle r) {/*....*/}
        public void DrawRectangle(Rectangle r) {/*....*/}
    }
}