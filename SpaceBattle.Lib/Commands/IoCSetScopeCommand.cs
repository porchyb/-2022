using System;
using System.Collections.Generic;

namespace SpaceBattle.Lib
{
    public class IoCSetScopeCommand: ICommand
    {
        Dictionary<string, IStrategy> scope;
        public IoCSetScopeCommand(Dictionary<string, IStrategy> _scope)
        {
            scope = _scope;
        }
        public void Execute()
        {
            IoC.SetScope(scope);
        }
    }
}
