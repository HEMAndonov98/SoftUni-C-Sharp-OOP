using System;
using BirthdayCelabrations.Core;
using BirthdayCelabrations.IO.Interfaces;
using BirthdayCelabrations.Models;
using BorderControl.IO;

namespace BirthdayCelabrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            Engine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}

