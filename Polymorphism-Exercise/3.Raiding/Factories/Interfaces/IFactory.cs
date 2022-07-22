using System;
using Raiding.Models.Interfaces;

namespace Raiding.Factories.Interfaces
{
    public interface IFactory
    {
        IHero CreateClass(string name, string type);
    }
}

