using System;
using System.Linq;

namespace _4.PizzaCalories.Pizza
{
    public class Dough
    {
        private const int BaseCaloriesPerGram = 2;
        private static readonly string[] FlourTypes = new string[] { "white", "wholegrain" };
        private static readonly string[] BakingTechniques = new string[] {"crispy", "chewy", "homemade" };
        private const int MinDoughWeight = 1;
        private const int MaxDoughWeight = 200;

        private string flourType;
		private string bakingTechnique;
		private double weight;

		public Dough(string flourType, string bakingTechnique, double weight)
		{
			this.FlourType = flourType;
			this.BakingTechnique = bakingTechnique;
			this.Weight = weight;
		}

        public string FlourType { get { return this.flourType; }
            private set
            {
                if (ValidateFlourType(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessage.InvalidDoug);
                }
                this.flourType = value;
            } }
        public string BakingTechnique { get { return this.bakingTechnique; }
            private set
            {
                if (ValidateBakingTechnique(value.ToLower()))
                {
                    throw new ArgumentException(ExceptionMessage.InvalidDoug);
                }
                this.bakingTechnique = value;
            } }
		public double Weight { get { return this.weight; }
            private set
            {
                if (value < MinDoughWeight || value > MaxDoughWeight)
                {
                    throw new ArgumentException(ExceptionMessage.InvalidDoughWeight);
                }
                this.weight = value;
            } }

        public double CalculateCalories()
        {
            double result = 0;
			var fourTypeModifier = GetFlourTypeModifier();
			var bakingTechniqueModifier = GetBakingTechniqueModifier();
            result = BaseCaloriesPerGram * this.Weight * fourTypeModifier;
            result = result * bakingTechniqueModifier;
            return result;
            
        }

		private double GetFlourTypeModifier()
        {
			var result = 0d;
            if (this.FlourType.ToLower() == "white")
            {
				result = 1.5;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
				result = 1;
            }

			return result;
        }
		private double GetBakingTechniqueModifier()
        {
			double result = 0;
            if (this.BakingTechnique.ToLower() == "crispy")
            {
				result = 0.9;
            }
            else if (this.bakingTechnique.ToLower() == "chewy")
            {
				result = 1.1;
            }
            else
            {
                result = 1;
            }
            return result;
        }

        private bool ValidateFlourType(string flourTypeVal)
            => !FlourTypes.Contains(flourTypeVal);
        private bool ValidateBakingTechnique(string technique)
            => !BakingTechniques.Contains(technique);
	}
}

