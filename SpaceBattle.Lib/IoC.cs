namespace SpaceBattle.Lib;

public class IoC{
    private static Dictionary<string, IStrategy> storage;
    static IoC(){
        storage = new Dictionary<string, IStrategy>();
        storage["IoC.Add"] = new IoCAddStrategy(storage);
        storage["IoC.Resolve"] = new IoCResolveStrategy(storage);
    }
    public static T Resolve<T>(string key, params object[] args){
        return (T)storage["IoC.Resolve"].UseStrategy(key, args);
    }
}
