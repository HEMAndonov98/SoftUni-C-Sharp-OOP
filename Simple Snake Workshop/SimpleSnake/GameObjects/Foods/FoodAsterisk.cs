namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char foodSymbol = '*';
        private const int foodPoint = 1;

        public FoodAsterisk(Wall wall)
            : base(wall, foodPoint, foodSymbol)
        {
        }
    }
}

