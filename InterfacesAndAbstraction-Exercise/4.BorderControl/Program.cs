using System;
using BorderControl.Core;
using BorderControl.IO;
using BorderControl.IO.Interfaces;

namespace BorderControl
{
    class Program
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

