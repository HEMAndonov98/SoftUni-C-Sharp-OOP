using System;
using WildFarm.ExceptionMessages;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WeightModifier = 0.35;

        public Hen(string name, double weight, double wingSize)
            :base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            double weightGained = food.Quantity * WeightModifier;
            this.Weight += weightGained;
            this.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}

