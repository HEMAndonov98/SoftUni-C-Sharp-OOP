using System;
namespace Raiding.Models
{
    public class Warrior : Hero
    {
        private const int warriorPower = 100;

        public Warrior(string name)
            :base(name, warriorPower)
        {
        }
    }
}

