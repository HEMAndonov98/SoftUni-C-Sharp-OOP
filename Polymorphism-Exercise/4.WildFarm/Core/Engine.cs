using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<IAnimal> animals;
        private IAnimal animal;
        private IFood food;
        private readonly Factory factory;
        //usually we pass in a reader and a writer as the engine arguments
        //here i'll just use the standard console class
        public Engine()
        {
            //option to create an IO folder and add a reader and a writer
            this.animals = new Collection<IAnimal>();
            this.factory = new Factory();
        }

        public void Run()
        {
            var isEven = true;
            string line;
            while ((line = Console.ReadLine()) != "End")
            {
                try
                {
                    if (isEven)
                    {
                        isEven = false;
                        GetAnimal(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                        this.animals.Add(this.animal);
                    }
                    else if (!isEven)
                    {
                        isEven = true;
                        GetFood(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                        Console.WriteLine(this.animal.ProduceSound());
                        this.animal.Eat(this.food);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            PrintAnimals();
        }

        private void PrintAnimals()
        {
            foreach (var animal in this.animals)
            {
                Console.WriteLine(animal);
            }
        }

        private void GetFood(string[] foodParams)
        {
            this.food = this.factory.CreateFood(foodParams);
        }

        private void GetAnimal(string[] animalParams)
        {
            this.animal = this.factory.CreateAnimal(animalParams);
        }
    }
}

