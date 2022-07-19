using System;
namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        public int Food { get; }

        public string Name { get; }

        public void BuyFood();
    }
}

