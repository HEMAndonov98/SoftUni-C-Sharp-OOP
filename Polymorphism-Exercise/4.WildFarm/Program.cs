using System;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            IFood veg = new Vegetable(50);
            Console.WriteLine(veg.GetType().Name);
        }
    }
}

