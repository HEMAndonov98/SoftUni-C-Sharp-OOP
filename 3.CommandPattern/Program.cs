// See https://aka.ms/new-console-template for more information

using CommandPattern.Models;
using CommandPattern.Models.Interfaces;

var modifyProduct = new ModifyProduct();
var product = new Product("Iphone 12", 1200);

Execute(product, modifyProduct, new ProductCommand(product, CommandPattern.Other.Enums.PriceAction.Increase, "100"));
Execute(product, modifyProduct, new ProductCommand(product, CommandPattern.Other.Enums.PriceAction.Decrease, "200"));
Execute(product, modifyProduct, new ProductCommand(product, CommandPattern.Other.Enums.PriceAction.Change, "Iphone 13"));


static void Execute(Product product, ModifyProduct modifyProduct, ICommand productCommand)
{
    modifyProduct.SetCommand(productCommand);
    modifyProduct.Invoke();
}