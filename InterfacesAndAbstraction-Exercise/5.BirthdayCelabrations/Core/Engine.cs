using System;
using System.Collections.Generic;
using System.Linq;
using BirthdayCelabrations.IO.Interfaces;
using BirthdayCelabrations.Models;
using BirthdayCelabrations.Models.Interfaces;

namespace BirthdayCelabrations.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<IBirthdate> birthdates;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.birthdates = new List<IBirthdate>();
        }

        public void Run()
        {
            ProcessBirdays();
            PrintOutput();
        }

        private void ProcessBirdays()
        {
            string line;
            while ((line = reader.ReadLine()) != "End")
            {
                var args = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToArray();

                IBirthdate birthdate;

                if (line.StartsWith("Citizen"))
                {
                    birthdate = new Citizen(args[0], int.Parse(args[1]), args[2], args[3]);
                }
                else if (line.StartsWith("Pet"))
                {
                    birthdate = new Pet(args[0], args[1]);
                }
                else
                {
                    continue;
                }

                birthdates.Add(birthdate);
            }
        }

        private void PrintOutput()
        {
            string yearToSearch = reader.ReadLine();
 
            foreach (var birthdate in birthdates.Where(b => b.Birthdate.EndsWith(yearToSearch)))
            {
                writer.WriteLine(birthdate.Birthdate);
            }
        }
    }
}

