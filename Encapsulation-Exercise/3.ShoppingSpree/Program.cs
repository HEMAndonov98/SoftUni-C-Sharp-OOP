using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();
            try
            {
                ProcessPeopleInput(people);
                ProcessProductsInput(products);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                var cmdArgs = cmd.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var customer = people.First(p => p.Name == cmdArgs[0]);
                var product = products.First(p => p.Name == cmdArgs[1]);

                if (customer.AddProduct(product))
                {
                    Console.WriteLine($"{customer.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{customer.Name} can't afford {product.Name}");
                }
            }

            people.ForEach(p => Console.WriteLine(p));

        }

        private static void ProcessProductsInput(List<Product> products)
        {
            var productArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var product in productArgs)
            {
                var productParams = product.Split('=', StringSplitOptions.RemoveEmptyEntries);
                products.Add(new Product(productParams[0].Trim(), decimal.Parse(productParams[1])));
            }
        }
        private static void ProcessPeopleInput(List<Person> people)
        {
            var personArgs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var person in personArgs)
            {
                    var personParams = person.Split('=', StringSplitOptions.RemoveEmptyEntries);
                    people.Add(new Person(personParams[0].Trim(), decimal.Parse(personParams[1])));
            }
        }
    }
}

