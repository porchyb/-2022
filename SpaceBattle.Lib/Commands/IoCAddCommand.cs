using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class IoCAddCommand: ICommand{
    private ConcurrentDictionary<string, IStrategy> storage;
    string key;
    IStrategy strategy;
    public IoCAddCommand(ConcurrentDictionary<string, IStrategy> _storage, string _key, IStrategy _strategy){
        this.storage = _storage;
        this.key = _key;
        this.strategy = _strategy;
    }
    public void Execute(){
        storage[key] = strategy;
    }
}
