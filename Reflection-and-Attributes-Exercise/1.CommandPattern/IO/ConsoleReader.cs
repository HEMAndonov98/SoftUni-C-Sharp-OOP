using System;
using CommandPattern.IO.Contracts;

namespace CommandPattern.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}

