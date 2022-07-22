using System;
namespace Raiding.Models
{
    public class Druid : Hero
    {
        private const int druidPower = 80;

        public Druid(string name)
            :base(name, druidPower)
        {
        }
    }
}

