using System;
namespace _4.PizzaCalories
{
	public abstract class ExceptionMessage
	{
		public const string InvalidDoug = "Invalid type of dough.";
		public const string InvalidDoughWeight = "Dough weight should be in the range [1..200].";
		public const string InvalidTopping = "Cannot place {0} on top of your pizza."; // {0} -> Name of the invalid topping
		public const string InvalidToppingWeight = "{0} weight should be in the range [1..50]."; // {0} -> Name of topping
		public const string InvalidName = "Pizza name should be between 1 and 15 symbols.";
		public const string ExceededMaxNumberOfToppins = "Number of toppings should be in range [0..10].";
    }
}

