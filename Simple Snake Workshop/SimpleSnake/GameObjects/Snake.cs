namespace SimpleSnake.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Snake
    {
        private const int BaseSnakeLength = 6;
        private const char snakeSymbol = '\u25CF';

        private Queue<Point> snakeElements;
        private List<Food> foods;
        private readonly Wall wall;
        private Random random;

        private int nextLeftX = 0;
        private int nextTopY = 0;
        private int foodIndex;
        private int RandomFoodNumber
            => this.random.Next(0, this.foods.Count);


        private Snake()
        {
            this.random = new Random();
            this.foods = new List<Food>();
            this.snakeElements = new Queue<Point>();
            this.foodIndex = this.RandomFoodNumber;
        }

        public Snake(Wall wall)
            :this()
        {
            this.wall = wall;
            this.GetFoods();
            this.CreateSnake();
        }

        public int Score => this.snakeElements.Count - BaseSnakeLength;

        public bool IsMoving(Point direction)
        {
            Point snakeHead = this.snakeElements.Last();

            this.GetNextPointOfDirection(direction, snakeHead);

            bool hasBittenSelf = this.snakeElements
                .Any(x => x.LeftX == this.nextLeftX && x.TopY == this.nextTopY);

            if (hasBittenSelf == true)
                return false;

            Point snakeNewHeadPosition = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHeadPosition))
                return false;

            this.snakeElements.Enqueue(snakeNewHeadPosition);
            snakeNewHeadPosition.Draw(snakeSymbol);

            if (this.foods[this.foodIndex].IsFoodPoint(snakeNewHeadPosition))
            {
                this.Eat(direction, snakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();
            snakeTail.Draw(' ');

            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[this.foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPointOfDirection(direction, currentSnakeHead);
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6 ; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }

            this.foodIndex = this.RandomFoodNumber;
            this.foods[this.foodIndex].SetRandomPosition(this.snakeElements);
        }

        private void GetFoods()
        {
            var allFoodTypes =
                Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name.StartsWith("Food") && t != typeof(Food));

            foreach (var foodType in allFoodTypes)
            {
                var food = (Food)Activator.CreateInstance(foodType, new object[] { this.wall });
                this.foods.Add(food);
            }
        }

        private void GetNextPointOfDirection(Point direction, Point snakeHead)
        {
            this.nextLeftX = direction.LeftX + snakeHead.LeftX;
            this.nextTopY = direction.TopY + snakeHead.TopY;
        }

    }
}

