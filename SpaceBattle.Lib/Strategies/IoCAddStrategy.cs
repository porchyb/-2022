using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class IoCAddStrategy: IStrategy{
    private ConcurrentDictionary<string, IStrategy> storage;
    public IoCAddStrategy(ConcurrentDictionary<string, IStrategy> _storage){
        this.storage = _storage;
    }
    public object UseStrategy(params object[] args){
        string key = (string)args[0];
        IStrategy strategy = (IStrategy)args[1];
        storage[key] = strategy;
        return new IoCAddCommand(storage, key, strategy);
    }
}
