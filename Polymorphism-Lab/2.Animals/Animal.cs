using System;
namespace Animals
{
    public class Animal
    {
        protected Animal(string name, string fovouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = fovouriteFood;
        }

        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}

