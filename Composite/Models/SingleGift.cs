namespace Composite.Models
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            :base(name, price)
        {

        }

        public override int CalculateTotalPrice()
        {
            //Again in real application this application will use writer class to write message
            Console.WriteLine($"{this.name} with the price {this.price}");
            return price;
        }
    }
}

