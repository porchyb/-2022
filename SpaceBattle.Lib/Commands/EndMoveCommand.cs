using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SpaceBattle.Lib
{
    public class EndMoveCommand: ICommand
    {        
        public IMoveEndable? obje { get;}
        //public IMoveStartable? cmd_F_del { get; set; }
        public Queue<ICommand> queue {get; set;}
        public EndMoveCommand (IMoveEndable obj){
            this.obje = obj;
            queue = IoC.Resolve<Queue<ICommand>>("Game.Queue");
        }
        public void Execute(){   
            ICommand changeVelocityCommand = new ChangeVelocityCommand(obje.target, null);
            queue.Enqueue(changeVelocityCommand);
            BridgeCommand EndCommand = new BridgeCommand(obje.MCommand);
            EndCommand.Inject(new EmptyCommand());
        }
    }
}
