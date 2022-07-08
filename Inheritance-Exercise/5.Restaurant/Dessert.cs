using System;
namespace Restaurant
{
	public class Dessert : Food
	{
		public Dessert(string name, decimal price, double grams, double calories) : base(name, price, grams)
        {
			this.Calorries = calories;
		}

        public double Calorries { get; set; }
    }
}

