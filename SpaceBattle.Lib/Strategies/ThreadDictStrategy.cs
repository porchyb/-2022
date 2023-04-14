namespace SpaceBattle.Lib;
using System.Collections.Concurrent;

public class threadDictStrategy: IStrategy{
    ConcurrentDictionary<int, MyThread> threadsDict;
    public threadDictStrategy(){
        threadsDict = new();
    }
    public object UseStrategy(params object[] args){
        return threadsDict;
    }
}
