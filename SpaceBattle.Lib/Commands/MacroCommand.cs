using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    public class MacroCommand: ICommand
    {
        private Queue<ICommand> queue {get; set;}
        public List<ICommand> commands;
        public MacroCommand(List<ICommand> _commands)
        {
            commands = _commands;
        }
        public void Execute()
        {
            queue = IoC.Resolve<Queue<ICommand>>("Game.Queue");
            foreach(var command in commands){
                queue.Enqueue(command);
            }
        }
    }
}
