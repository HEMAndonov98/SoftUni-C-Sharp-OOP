using System;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Mammals
{
    public abstract class Mammal: IAnimal
    {
        //Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}"
        protected Mammal(string name, double weight, string livingRegion)
        {
            this.Name = name;
            this.Weight = weight;
            this.LivingRegion = livingRegion;
            this.FoodEaten = 0;
        }

        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public string LivingRegion { get; protected set; }

        public abstract void Eat(IFood food);
    }
}

