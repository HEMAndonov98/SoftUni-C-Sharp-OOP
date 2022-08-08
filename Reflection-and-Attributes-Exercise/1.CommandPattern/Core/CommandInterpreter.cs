using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] argsSplit = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = $"{argsSplit[0]}Command";
            var commandArgs = new object[] { argsSplit.Skip(1).ToArray() };

            Assembly assembly = Assembly.GetEntryAssembly();

            Type cmdType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName &&
                                t.GetInterfaces()
                                .Any(i => i == typeof(ICommand)));
            if (cmdType == null)
                throw new InvalidOperationException();

            MethodInfo method = cmdType.GetMethod("Execute");

            object command = Activator.CreateInstance(cmdType);

            string result = (string)method.Invoke(command, commandArgs);

            return result;
        }
    }
}

