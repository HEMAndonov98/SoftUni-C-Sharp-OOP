
namespace Composite.Models
{

    using Composite.Models.Interfaces;

    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;

        public CompositeGift(string name, int price)
            :base(name, price)
        {
            this.gifts = new HashSet<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            this.gifts.Add(gift);
        }

        public bool Remove(GiftBase gift)
            => this.gifts.Remove(gift);

        public override int CalculateTotalPrice()
        {
            int netPrice = 0;
            //In real application reader and writer need to be implemented
            Console.WriteLine($"{this.name} contains the following products with prices:");

            foreach (var gift in this.gifts)
            {
                netPrice += gift.CalculateTotalPrice();
            }
            return netPrice;
        }
    }
}

