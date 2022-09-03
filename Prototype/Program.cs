using Prototype.Models;

var menu = new SandwichMenu();

//These are the default sandwiches
menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
menu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
menu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

//These are the clones

var bltClone = menu["BLT"].Clone();
var pbJClone = menu["PB&J"].Clone();
var turkeyClone = menu["Turkey"].Clone();
