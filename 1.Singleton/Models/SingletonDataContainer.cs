namespace _1.Singleton.Models
{
    using System;
    using _1.Singleton.Models.Interfaces;

    public sealed class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();
        private static SingletonDataContainer instance = new SingletonDataContainer();

        private SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("/Volumes/Extreme SSD/SoftUni C# OOP/1.Singleton/capitals.txt");
            for (int i = 0; i < elements.Length; i+= 2)
            {
                this._capitals[elements[i]] = int.Parse(elements[i + 1]);
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return this._capitals[name];
        }
    }
}

