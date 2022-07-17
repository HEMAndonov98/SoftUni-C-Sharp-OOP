using System;
using System.Collections.Generic;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly List<IIdentifiable> visitors;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.visitors = new List<IIdentifiable>();
        }

        public void Run()
        {
            ProcessVisitors();

            string fakeIdIdentifier = reader.ReadLine();
            visitors.RemoveAll(v => !v.Id.EndsWith(fakeIdIdentifier));

            foreach (var removedVisitor in visitors)
            {
                writer.WriteLine(removedVisitor.Id);
            }
        }

        private void ProcessVisitors()
        {
            string line;
            while ((line = reader.ReadLine()) != "End")
            {
                var args = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                IIdentifiable visitor;

                if (args.Length == 3)
                {
                    visitor = new Citizen(args[0], int.Parse(args[1]), args[2]);
                }
                else
                {
                    visitor = new Robot(args[0], args[1]);
                }
                visitors.Add(visitor);
            }
        }
    }
}

