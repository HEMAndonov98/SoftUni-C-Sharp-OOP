using System;
using System.Collections.Generic;

namespace _3.ShoppingSpree
{
	public class Person
	{
		private const int MinMoney = 0;

		private string name;
		private decimal money;
		private List<Product> bagOfProducts;

		public Person(string name, decimal money)
		{
			this.Name = name;
			this.Money = money;
			this.bagOfProducts = new List<Product>();
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
		public decimal Money
        {
			get { return this.money; }
			private set
            {
                if (value < MinMoney)
                {
					throw new ArgumentException(ExceptionMessages.NegativeMoneyValue);
                }
				this.money = value;
            }
        }

		public bool AddProduct(Product product)
        {
            bool result = false;
            if (this.Money >= product.Cost)
            {
                this.bagOfProducts.Add(product);
                this.Money -= product.Cost;
                result = true;
            }
            return result;
        }
        public override string ToString()
        {
            return $"{this.Name} - {(this.bagOfProducts.Count > 0? string.Join(", ", bagOfProducts) : "Nothing bought")}";
        }
    }
}

