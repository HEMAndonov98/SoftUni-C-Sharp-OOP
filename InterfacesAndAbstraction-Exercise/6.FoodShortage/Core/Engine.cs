using System;
using System.Collections.Generic;
using System.Linq;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;

namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<IBuyer> buyers;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.buyers = new List<IBuyer>();
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] lineArgs = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                IBuyer buyer;
                if (lineArgs.Length == 4)
                {
                    buyer = new Citizen(lineArgs[0], int.Parse(lineArgs[1]), lineArgs[2], lineArgs[3]);
                }
                else
                {
                    buyer = new Rebel(lineArgs[0], int.Parse(lineArgs[1]), lineArgs[2]);
                }
                buyers.Add(buyer);
            }
            string line;
            while ((line= reader.ReadLine()) != "End")
            {
                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == line);

                if (buyer == null)
                {
                    continue;
                }

                buyer.BuyFood();
            }

            writer.WriteLine(buyers.Select(b => b.Food).Sum().ToString());
        }        
    }
}

