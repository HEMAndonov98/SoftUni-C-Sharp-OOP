namespace SimpleSnake.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Snake
    {
        private Queue<Point> snakeElements;
        private List<object> foods;
        private readonly Wall wall;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new List<object>();
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6 ; topY++)
            {
                this.snakeElements.Enqueue(new Point(2, topY));
            }
        }

        public void GetFoods()
        {
            var allFoodTypes =
                Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name.StartsWith("Food") && t != typeof(Food));

            foreach (var foodType in allFoodTypes)
            {
                var food = Activator.CreateInstance(foodType, new object[] { this.wall });
                this.foods.Add(food);
            }
        }
    }
}

