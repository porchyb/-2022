using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class ExceptionHandlerDefaultStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        throw new Exception();
    }
}
