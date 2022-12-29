namespace SpaceBattle.Lib;

public class IoCResolveStrategy: IStrategy{
    private Dictionary<string, IStrategy> storage;
    public IoCResolveStrategy(Dictionary<string, IStrategy> _storage){
        this.storage = _storage;
    }
    public object UseStrategy(params object[] _args){
        string key = (string)_args[0];
        object[] args = (object[])_args[1];
        return storage[key].UseStrategy(args);
    }
}
