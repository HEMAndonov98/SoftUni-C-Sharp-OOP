using System;
using WildFarm.ExceptionMessages;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WeightModifier = 0.10;

        public Mouse(string name, double weight, string livingRegion)
            :base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            string foodType = food.GetType().Name;
            if (foodType == "Vegetable" || foodType == "Fruit")
            {
                double weightGained = food.Quantity * WeightModifier;
                this.Weight += weightGained;
                this.FoodEaten += food.Quantity;
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

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}

