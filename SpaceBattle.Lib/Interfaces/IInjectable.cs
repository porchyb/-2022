using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Lib
{
    public interface IInjectable
    {
        public void Inject(ICommand other);
    }
    
    public class BridgeCommand: ICommand, IInjectable
    {
        public ICommand internalCommand 
        { get; set;}
        public IMoveStartable? Cmd_F_del { get; }

        public BridgeCommand(ICommand cmd)
        {
            internalCommand = cmd;
        }

        public BridgeCommand(IMoveStartable? cmd_F_del)
        {
            Cmd_F_del = cmd_F_del;
        }

        public void Inject(ICommand other)
        {
            internalCommand = other;
        }

        public void Execute()
        {
            internalCommand.Execute();
        }

    }
}
