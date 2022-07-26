using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var shape1 = new Circle();
            var shape2 = new Rectangle();
            var shape3 = new Tetrahedron();

            var graphEdit = new GraphicEditor();
            graphEdit.DrawShape(shape1);
            graphEdit.DrawShape(shape2);
            graphEdit.DrawShape(shape3);
        }
    }
}
