using System;
namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood)
            :base(name, favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }

        public override string ExplainSelf()
        {
            return base.ExplainSelf() +
                Environment.NewLine +
                "DJAAF";
        }
    }
}

