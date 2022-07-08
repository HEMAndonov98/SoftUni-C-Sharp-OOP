using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            Console.WriteLine(new Child(name, age));
        }
    }
}