using System;
namespace _3.ShoppingSpree
{
	public class Product
	{
        private int MinCost = 0;

		private string name;
		private decimal cost;

		public Product(string name, decimal cost)
		{
            this.Name = name;
            this.Cost = cost;
		}

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmptyNameException);
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get { return this.cost; }
            private set
            {
                if (value < MinCost)
                {
                    throw new ArgumentException(ExceptionMessages.NegativeMoneyValue);
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}

