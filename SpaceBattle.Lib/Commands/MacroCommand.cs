using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceBattle.Lib
{
    public class MacroCommand: ICommand
    {
        public Queue<ICommand> queue {get; set;}
        List<ICommand> commands;
        object obj;
        public MacroCommand(List<ICommand> _commands, object _obj)
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
