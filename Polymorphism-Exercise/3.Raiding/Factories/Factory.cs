using System;
using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding.Factories
{
    public class Factory : IFactory
    {
        public IHero CreateClass(string name, string type)
        {
            if (type == "Druid")
            {
                return new Druid(name);
            }
            else if (type == "Paladin")
            {
                return new Paladin(name);
            }
            else if (type == "Rogue")
            {
                return new Rogue(name);
            }
            else if (type == "Warrior")
            {
                return new Warrior(name);
            }

            throw new ArgumentException("Invalid hero!");
        }
    }
}

