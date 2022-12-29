namespace SpaceBattle.Lib;

public class IoCAddCommand: ICommand{
    private Dictionary<string, IStrategy> storage;
    string key;
    IStrategy strategy;
    public IoCAddCommand(Dictionary<string, IStrategy> _storage, string _key, IStrategy _strategy){
        this.storage = _storage;
        this.key = _key;
        this.strategy = _strategy;
    }
    public void Execute(){
        storage[key] = strategy;
    }
}
