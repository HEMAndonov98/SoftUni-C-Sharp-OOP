using System;
using WildFarm.Core;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Foods;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}

