using System;
using System.Linq;

namespace _4.PizzaCalories.Pizza
{
    public class Topping
    {
        private const double BaseCaloriesPerGram = 2;

        private readonly static string[] AllTypes = new string[] { "meat", "veggies", "cheese", "sauce" };
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }


        public string Type
        {
            get { return this.type; }
            private set
            {
                if (ValidateTopping(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.InvalidTopping, value));
                }
                this.type = value;
            }
        }
        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.InvalidToppingWeight, this.Type));
                }
                this.weight = value;
            }
        }

        private bool ValidateTopping(string value)
            => !AllTypes.Contains(value);
        private double GetToppingModifier()
        {
            double caloriesPerGram = 1;
            if (this.Type.ToLower() == "meat")
            {
                caloriesPerGram = 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                caloriesPerGram = 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                caloriesPerGram = 1.1;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                caloriesPerGram = 0.9;
            }
            return caloriesPerGram;
        }
        public double CalculateCalories()
        {
            var modifier = GetToppingModifier();
            return BaseCaloriesPerGram * this.Weight * modifier;
        }
    }
}

