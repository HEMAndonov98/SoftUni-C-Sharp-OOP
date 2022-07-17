using System;
using BirthdayCelabrations.Models.Interfaces;

namespace BirthdayCelabrations.Models
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        private string Name;

        public string Birthdate { get; private set; }
    }
}

