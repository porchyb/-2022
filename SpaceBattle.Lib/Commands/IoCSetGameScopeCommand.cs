using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBattle.Lib.Commands
{
    internal class IoCSetGameScopeCommand : ICommand
    {
        Dictionary<string, IStrategy> scope;
        public IoCSetGameScopeCommand(Dictionary<string, IStrategy>)
        {

        }
        public void Execute()
        {
            
        }
    }
}
