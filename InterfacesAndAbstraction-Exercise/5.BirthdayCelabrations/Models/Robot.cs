using System;
using BirthdayCelabrations.Models.Interfaces;

namespace BirthdayCelabrations.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        private string Model;

        public string Id { get; private set; }
    }
}

