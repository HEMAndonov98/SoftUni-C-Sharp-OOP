using System;

namespace BorderControl.Models
{
    using Interfaces;

    public class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }
        private string Name;

        private int Age;

        public string Id { get; private set; }
    }
}

