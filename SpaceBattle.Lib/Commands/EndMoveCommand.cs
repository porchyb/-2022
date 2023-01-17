using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SpaceBattle.Lib
{
    #nullable enable
    public class EndMoveCommand: ICommand
    {
        #nullable enable
        public IMoveEndable? obj { get;}
        public IMoveStartable? cmd_F_del { get; set; }
        public Queue<ICommand>? queue {get; set;}
        public EndMoveCommand (ICommand cmd){
            BridgeCommand EndCommand = new BridgeCommand(cmd);
        }
        public void Execute(){
            ICommand cmd = new MoveCommand(obj);
            BridgeCommand EndCommand = new BridgeCommand(cmd_F_del);
            EndCommand.Inject(new EmptyCommand());
        }
    }
}
