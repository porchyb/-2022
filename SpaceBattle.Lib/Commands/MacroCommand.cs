using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    public class MacroCommand: ICommand
    {
        public List<ICommand> commands;
        public MacroCommand(List<ICommand> _commands)
        {
            commands = _commands;
        }
        public void Execute()
        {
            commands.ForEach(a=>a.Execute());
        }
    }
}
