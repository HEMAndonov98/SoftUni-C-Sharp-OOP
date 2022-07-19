using System;
using FoodShortage.IO.Interfaces;

namespace FoodShortage.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}

