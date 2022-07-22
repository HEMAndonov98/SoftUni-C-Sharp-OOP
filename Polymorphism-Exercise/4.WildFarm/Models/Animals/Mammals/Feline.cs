using System;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed)
            :base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; protected set; }

        public override void Eat(IFood food)
        {
            this.Weight += food.Quantity;
        }
    }
}

