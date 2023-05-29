using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class GetExceptionHandlerDefaultStrategy : IStrategy
{
    public object UseStrategy(params object[] args)
    {
        return new ExceptionHandlerDefaultStrategy();
    }
}

public class ExceptionHandlerDefaultStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        throw new Exception();
    }
}
