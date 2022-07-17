using System;

namespace BirthdayCelabrations.Models
{
    using System.Globalization;
    using Interfaces;

    public class Citizen : IIdentifiable , IBirthdate
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        private string Name;

        private int Age;

        public string Id { get; private set; }

        public string Birthdate { get; private set; }
    }
}

