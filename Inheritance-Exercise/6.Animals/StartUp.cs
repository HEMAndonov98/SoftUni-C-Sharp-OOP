using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            string className;
            while ((className = Console.ReadLine()) != "Beast!")
            {
                var lines = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (className == "Frog")
                {
                    var  frog = new Frog(lines[0], int.Parse(lines[1]), lines[2]);
                    animals.Add(frog);
                }
                else if (className == "Dog")
                {
                   var dog = new Dog(lines[0], int.Parse(lines[1]), lines[2]);
                    animals.Add(dog);

                }
                else if (className == "Cat")
                {
                     var cat = new Cat(lines[0], int.Parse(lines[1]), lines[2]);
                    animals.Add(cat);
                }
                else if (className == "Kittens")
                {
                    var kitten = new Kitten(lines[0], int.Parse(lines[1]));
                    animals.Add(kitten);
                }
                else if (className == "Tomcat")
                {
                   var  tomCat = new Tomcat(lines[0], int.Parse(lines[1]));
                    animals.Add(tomCat);
                }
            }
            foreach (var animal in animals)
            {
                if (animal.IsValid)
                {
                    Console.WriteLine(animal);
                }
            }

        }
    }
}
