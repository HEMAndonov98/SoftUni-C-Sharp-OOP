namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char foodSymbol = '#';
        private const int foodPoint = 3;

        public FoodHash(Wall wall)
            : base(wall, foodPoint, foodSymbol)
        {
        }
    }
}

