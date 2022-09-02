using System;
using CommandPattern.Models.Interfaces;

namespace CommandPattern.Models
{
    public class ModifyProduct
    {
        private readonly List<ICommand> _commands;
        private ICommand? _command;

        public ModifyProduct()
        {
            this._commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
            => this._command = command;

        public void Invoke()
        {
            if (this._command != null)
            {
                _commands.Add(_command);
                _command.Execute();
            }
        }
    }
}

