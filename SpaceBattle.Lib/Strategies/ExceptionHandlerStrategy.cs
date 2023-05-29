using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class ExceptionHandlerStrategy : IStrategy{
    public object UseStrategy(params object[] args){
        ICommand command = (ICommand)args[0];
        Type commandType = command.GetType();
        Exception exception = (Exception)args[1];
        var strategies = IoC.Resolve<Dictionary<Type, Dictionary<Exception, IStrategy>>>("Handler.Strategies");
        try
        {
            var handledExceptionStrategy = strategies[commandType][exception];
            object res = handledExceptionStrategy.UseStrategy();
            return res;
        }
        catch
        {
            var handledExceptionStrategy = IoC.Resolve<IStrategy>("Handler.Default");
            object res = handledExceptionStrategy.UseStrategy();
            return res;
        }
    }
}
