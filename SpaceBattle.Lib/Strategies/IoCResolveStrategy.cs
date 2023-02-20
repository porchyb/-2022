using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class IoCResolveStrategy: IStrategy{
    private ConcurrentDictionary<string, IStrategy> storage;
    public IoCResolveStrategy(ConcurrentDictionary<string, IStrategy> _storage){
        this.storage = _storage;
    }
    public object UseStrategy(params object[] _args){
        string key = (string)_args[0];
        object[] args = (object[])_args[1];
        return storage[key].UseStrategy(args);
    }
}
