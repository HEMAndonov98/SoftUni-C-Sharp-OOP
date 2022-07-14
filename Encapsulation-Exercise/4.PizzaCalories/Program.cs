using System;
using System.Linq;
using _4.PizzaCalories.Pizza;

namespace _4.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                var doughtArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var dough = new Dough(doughtArgs[1], doughtArgs[2], double.Parse(doughtArgs[3]));
                var pizza = new PizzaObj(pizzaName[0], dough);
                string input;
                while ((input = Console.ReadLine()) != "END")
                {
                    var inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
                    var newTopping = new Topping(inputArgs[0], double.Parse(inputArgs[1]));
                    pizza.AddTopping(newTopping);
                }
                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

