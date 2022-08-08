using System;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Commands
{
    public class ExitCommand: ICommand
    {
        private static int NoErrorExit = 0;

        public string Execute(string[] args)
        {
            Environment.Exit(NoErrorExit);
            return null;
        }
    }
}

