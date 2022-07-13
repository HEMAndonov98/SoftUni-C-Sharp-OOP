using System;
using _4.PizzaCalories.Pizza;

namespace _4.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var dough = new Dough("White", "Chewy", 100);
            Console.WriteLine(dough.CalculateCalories());
        }
    }
}

