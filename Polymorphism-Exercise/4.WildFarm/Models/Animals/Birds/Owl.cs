using System;
using WildFarm.ExceptionMessages;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double WeightModifier = 0.25;

        public Owl(string name, double weight, double wingSize)
            :base(name, weight, wingSize)
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

