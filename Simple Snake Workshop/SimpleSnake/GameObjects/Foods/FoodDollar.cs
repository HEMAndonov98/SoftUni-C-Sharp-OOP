namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char foodSymbol = '$';
        private const int foodPoint = 2;

        public FoodDollar(Wall wall)
            : base(wall, foodPoint, foodSymbol)
        {
        }
    }
}

