using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class IoCSetScopeStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        Dictionary<string, IStrategy> scope = (Dictionary<string, IStrategy>)args[0];
        return new IoCSetScopeCommand(scope);
    }
}
