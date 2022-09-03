using System;
namespace Template.Models
{
    public abstract class Bread
    {
        public abstract void MixIngredients();
        public abstract void Bake();

        public virtual void Slice()
        {
            //Writer will be implemented in real application!
            Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
        }

        //This is the template methods
        public void Make()
        {
            this.MixIngredients();
            this.Bake();
            this.Slice();
        }
    }
}

