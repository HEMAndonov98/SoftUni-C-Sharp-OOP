using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        //Refactored the method so now it can "draw" any kind of shape without having to check for it's type
        //In the future a new shape can be added that must implement IShape and the method will work for it as well.
        //See Tetrahedron class.
        public void DrawShape(IShape shape)
        {
            Console.WriteLine($"I'm a {shape.GetType().Name}");
        }
    }
}
