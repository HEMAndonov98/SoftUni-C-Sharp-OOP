using System;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        void Eat(IFood food);
        string ProduceSound();
    }
}

