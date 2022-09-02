using System;
namespace CommandPattern.Models
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void IncreasePrice(int amount)
        {
            this.Price += amount;
            Console.WriteLine($"The price for the {this.Name} has been increased by {amount}$.");
        }

        public void DecreadePrice(int amount)
        {
            this.Price -= amount;
            Console.WriteLine($"The price for the {this.Name} has beed decreased by {amount}$.");
        }

        public void ChangeName(string newName)
        {
            string oldName = this.Name;
            this.Name = newName;

            Console.WriteLine($"Name has been successfuly changed to {newName} from {oldName}.");
        }

        public override string ToString()
            => $"Current price for the {this.Name} product is {this.Price}$.";
    }
}

