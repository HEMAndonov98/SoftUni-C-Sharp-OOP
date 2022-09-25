namespace SimpleSnake.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Random random;
        private readonly Wall wall;
        private readonly char foodSymbol;

        protected Food(Wall wall, int foodPoints, char foodSymbol)
            :base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.FoodPoints = foodPoints;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, this.wall.LeftX - 2);
            this.TopY = random.Next(2, this.wall.TopY - 2);

            while (snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY))
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);
            }

            var backgroundColor = this.random.Next(2, 16);

            Console.BackgroundColor = (ConsoleColor)backgroundColor;
            this.Draw(this.foodSymbol);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.LeftX == this.LeftX &&
                snake.TopY == this.TopY;
        }
    }
}

