using System;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Factories.Interfaces
{
    public interface IFactory
    {
        IAnimal CreateAnimal(string[] animalArgs);
        IFood CreateFood(string[] foodParams);
    }
}

