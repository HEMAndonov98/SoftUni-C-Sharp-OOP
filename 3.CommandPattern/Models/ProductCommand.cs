
namespace CommandPattern.Models
{
    using CommandPattern.Models.Interfaces;
    using CommandPattern.Other.Enums;

    public class ProductCommand : ICommand
    {
        private readonly Product _product;
        private readonly PriceAction _priceAction;
        private readonly string _arg;


        public ProductCommand(Product product, PriceAction priceAction, string arg)
        {
            this._product = product;
            this._priceAction = priceAction;
            this._arg = arg;
        }

        public void Execute()
        {
            if (this._priceAction == PriceAction.Increase)
            {
                this._product.IncreasePrice(int.Parse(this._arg));
            }
            else if (this._priceAction == PriceAction.Decrease)
            {
                this._product.DecreadePrice(int.Parse(this._arg));
            }
            else if (this._priceAction == PriceAction.Change)
            {
                this._product.ChangeName(this._arg);
            }
        }
    }
}

