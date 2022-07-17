using System;
using BorderControl.Models.Interfaces;

namespace BorderControl.Models
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

