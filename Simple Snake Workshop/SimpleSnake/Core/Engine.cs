using System.Threading;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private readonly Point[] pointsOfDirection;
        private readonly Snake snake;
        private readonly Wall wall;
        private Direction direction;
        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.sleepTime = 100;
            this.pointsOfDirection = new Point[4];
        }

        public void Run()
        {
            this.CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    this.GetNextDirection();
                }

                bool isMoving = this.snake
               .IsMoving(this.pointsOfDirection[(int)this.direction]);

                if (isMoving == false)
                {
                    this.AskUserForRestart();
                }

                this.sleepTime -= 0.01;

                Thread.Sleep((int)this.sleepTime);
            }
        }

        private void CreateDirections()
        {
            //Left
            this.pointsOfDirection[0] = new Point(-1, 0);
            //Right
            this.pointsOfDirection[1] = new Point(1, 0);
            //Down
            this.pointsOfDirection[2] = new Point(0, -1);
            //Up
            this.pointsOfDirection[3] = new Point(0, 1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            this.SetDirection(userInput);

            Console.CursorVisible = false;
        }

        private void SetDirection(ConsoleKeyInfo userInput)
        {
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (this.direction != Direction.Right)
                {
                    this.direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (this.direction != Direction.Left)
                {
                    this.direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (this.direction != Direction.Down)
                {
                    this.direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (this.direction != Direction.Up)
                {
                    this.direction = Direction.Down;
                }
            }
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX - 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                this.StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }
    }
}

