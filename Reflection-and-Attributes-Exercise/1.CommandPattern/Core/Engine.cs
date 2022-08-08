using System;
using CommandPattern.Core.Contracts;
using CommandPattern.IO.Contracts;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;
        private ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string input = reader.ReadLine();
                this.writer.WriteLine(this.commandInterpreter.Read(input));
            }
        }
    }
}

