using System;
using WildFarm.ExceptionMessages;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Mammals
{
    public class Cat : Feline
    {
        private const double WeightModifier = 0.30;

        public Cat(string name, double weight, string livingRegion, string breed)
            :base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Vegetable" || foodType == "Meat")
            {
                double weightGained = food.Quantity * WeightModifier;
                this.Weight += weightGained;
            }
            else
            {
                throw new ArgumentException
                    (
                    string.Format(ExceptionMessage.InvalidFoodGiven,
                    this.GetType().Name,
                    food.GetType().Name)
                    );
            }
        }
    }
}

