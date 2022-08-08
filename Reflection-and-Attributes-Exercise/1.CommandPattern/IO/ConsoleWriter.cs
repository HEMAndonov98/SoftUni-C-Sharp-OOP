using System;
using CommandPattern.IO.Contracts;

namespace CommandPattern.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }
    }
}

