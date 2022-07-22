using System;
using System.Runtime.CompilerServices;

namespace Raiding.Models
{
    public class Rogue : Hero
    {
        private const int roguePower = 80;

        public Rogue(string name)
            :base(name, roguePower)
        {
        }
    }
}

