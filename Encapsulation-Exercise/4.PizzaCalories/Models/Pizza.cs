using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.PizzaCalories.Pizza
{
	public class PizzaObj
	{
		private const int MaxNumberOfToppins = 10;

		private string name;
		private  List<Topping> toppings;
		private readonly Dough dough;

		public PizzaObj(string name, Dough dough)
		{
			this.Name = name;
			this.dough = dough;
			this.toppings = new List<Topping>();
		}

        public string Name
		{
			get { return this.name; }
			private set
			{
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
					throw new ArgumentException(ExceptionMessage.InvalidName);
                }
				this.name = value;
			}
		}

		public IReadOnlyCollection<Topping> Toppings
        {
			get { return this.toppings.AsReadOnly(); }
        }


		public double CalculateCalories()
			=> this.dough.CalculateCalories() + this.Toppings.Select(t => t.CalculateCalories()).Sum();
		public void AddTopping(Topping topping)
        {
			this.toppings.Add(topping);
            if (this.Toppings.Count > MaxNumberOfToppins)
            {
				this.toppings.Remove(topping);
				throw new ArgumentException(ExceptionMessage.ExceededMaxNumberOfToppins);
            }
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.CalculateCalories():F2} Calories.";
        }
    }
}

