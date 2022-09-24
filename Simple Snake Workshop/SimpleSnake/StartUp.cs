namespace SimpleSnake
{
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            //ConsoleWindow.CustomizeConsole();
            var wall = new Wall(50, 20);
            var snake = new Snake(wall);

            snake.GetFoods();
        }
    }
}
