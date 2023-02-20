using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class IoC{
    private static ConcurrentDictionary<string, IStrategy> storage;
    static IoC(){
        storage = new ConcurrentDictionary<string, IStrategy>();
        storage["IoC.Add"] = new IoCAddStrategy(storage);
        storage["IoC.Resolve"] = new IoCResolveStrategy(storage);
    }
    public static T Resolve<T>(string key, params object[] args){
        return (T)storage["IoC.Resolve"].UseStrategy(key, args);
    }
}
