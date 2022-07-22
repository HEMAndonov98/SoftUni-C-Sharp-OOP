using System;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Factories
{
    public class Factory : IFactory
    {
        public IAnimal CreateAnimal(string[] animalArgs)
        {
            string type = animalArgs[0];
            if (type == "Owl")
            {
                return new Owl(animalArgs[1], double.Parse(animalArgs[2]), double.Parse(animalArgs[3]));
            }
            else if (type == "Hen")
            {
                return new Hen(animalArgs[1], double.Parse(animalArgs[2]), double.Parse(animalArgs[3]));
            }
            else if (type == "Mouse")
            {
                return new Mouse(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]);
            }
            else if (type == "Dog")
            {
                return new Dog(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3]);
            }
            else if (type == "Cat")
            {
                return new Cat(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]);
            }
            else if (type == "Tiger")
            {
                return new Tiger(animalArgs[1], double.Parse(animalArgs[2]), animalArgs[3], animalArgs[4]);
            }

            throw new ArgumentException("Invalid Animal!");
        }

        public IFood CreateFood(string[] foodParams)
        {
            string type = foodParams[0];
            int quantity = int.Parse(foodParams[1]);
            if (type == "Fruit")
            {
                return new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                return new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                return new Seeds(quantity);
            }
            else if (type == "Vegetable")
            {
                return new Vegetable(quantity);
            }

            throw new ArgumentException("Invalid food!");
        }
    }
}

