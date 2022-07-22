using System;
using Raiding.Models.Abilitymessages;
using Raiding.Models.Interfaces;

namespace Raiding.Models
{
    public abstract class Hero : IHero
    {
        protected Hero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; protected set; }

        public int Power { get; protected set; }

        public string CastAbility()
        {
            string curClass = this.GetType().Name;

            if (curClass == "Druid" || curClass == "Paladin")
            {
                return String.Format(AbilityMsg.healedMsg, curClass, this.Name, this.Power);
            }
            else if (curClass == "Rogue" || curClass == "Warrior")
            {
                return String.Format(AbilityMsg.damageMsg, curClass, this.Name, this.Power);
            }

            return string.Empty;
        }
    }
}

