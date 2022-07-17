using System;
using BorderControl.IO.Interfaces;

namespace BorderControl.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}

