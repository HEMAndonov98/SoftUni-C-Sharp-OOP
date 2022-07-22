using System;
using WildFarm.ExceptionMessages;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Mammals
{
    public class Tiger : Feline
    {
        private const double WeightModifier = 1;

        public Tiger(string name, double weight, string livingRegion, string breed)
            :base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food.GetType().Name == "Meat")
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

