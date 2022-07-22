using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Raiding.Core.Interfaces;
using Raiding.Factories;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<IHero> heroes;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroes = new Collection<IHero>();
        }

        public void Run()
        {
            CreateRaidingGroup();
            Raid();
        }
     
        private void Raid()
        {
            int bossPower = int.Parse(reader.ReadLine());
            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            PrintOutput(bossPower);
        }

        private void CreateRaidingGroup()
        {
            var factory = new Factory();
            int n = int.Parse(reader.ReadLine());
            while (this.heroes.Count < n)
            {
                try
                {
                    string name = reader.ReadLine();
                    string type = reader.ReadLine();
                    heroes.Add(factory.CreateClass(name, type));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }

        private void PrintOutput(int bosspower)
        {
            if (heroes.Sum(h => h.Power) >= bosspower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}