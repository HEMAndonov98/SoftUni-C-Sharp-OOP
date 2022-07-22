using System;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; protected set; }
    }
}

