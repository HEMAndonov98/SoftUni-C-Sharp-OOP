using System;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
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

