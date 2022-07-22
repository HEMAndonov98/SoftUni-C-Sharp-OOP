using System;
using WildFarm.ExceptionMessages;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double WeightModifier = 0.40;

        public Dog(string name, double weight, string livingRegion)
            :base(name, weight, livingRegion)
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

