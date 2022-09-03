using Composite.Models;

var iPhone = new SingleGift("Iphone 12", 1200);
iPhone.CalculateTotalPrice();
Console.WriteLine();

var giftBox = new CompositeGift("box", 0);
var truck = new SingleGift("Truck", 280);
var plane = new SingleGift("Plane", 150);
giftBox.Add(truck);
giftBox.Add(plane);
var childBox = new CompositeGift("ChildBox", 0);
var toySoldier = new SingleGift("Toy Soldier", 100);
childBox.Add(toySoldier);
giftBox.Add(childBox);

Console.WriteLine($"Total price of this composite present is: {giftBox.CalculateTotalPrice()}");