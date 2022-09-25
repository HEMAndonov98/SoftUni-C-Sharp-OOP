namespace SimpleSnake
{
    using System.Text;
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = false;

            var wall = new Wall(60, 20);
            var snake = new Snake(wall);

            var engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
