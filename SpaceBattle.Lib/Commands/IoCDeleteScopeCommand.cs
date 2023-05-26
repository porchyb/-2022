using System;
using System.Collections.Generic;

namespace SpaceBattle.Lib
{
    public class IoCDeleteScopeCommand: ICommand
    {
        List<string> scopeKeys;
        public IoCDeleteScopeCommand(List<string> _scopeKeys)
        {
            scopeKeys = _scopeKeys;
        }
        public void Execute()
        {
            IoC.DeleteScope(scopeKeys);
        }
    }
}
