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
    public static void SetScope(Dictionary<string, IStrategy> scope){
        scope.AsParallel().ForAll(item => {
            IoC.Resolve<ICommand>("IoC.Add", item.Key, item.Value).Execute();
        });
    }
    public static void DeleteScope(List<string> removed)
    {
        removed.ForEach(a =>
        {
            IStrategy? defStrategy;
            storage.TryRemove(a, out defStrategy);
        });
    }
}
