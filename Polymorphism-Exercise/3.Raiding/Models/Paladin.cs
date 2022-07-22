using System;
namespace Raiding.Models
{
    public class Paladin : Hero
    {
        private const int paladinPower = 100;

        public Paladin(string name)
            :base(name, paladinPower)
        {
        }
    }
}

