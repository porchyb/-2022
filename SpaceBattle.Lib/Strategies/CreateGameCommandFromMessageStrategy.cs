namespace SpaceBattle.Lib;
using Hwdtech;


public class CreateGameCommandFromMessageStrategy : IStrategy 
{
    public object UseStrategy(params object[] args)
    {
        IInterpretingMessage message = (IInterpretingMessage)args[0];

        var obj = Hwdtech.IoC.Resolve<IUObject>("Game.Get.UObject", message.ObjectID);

        message.Parameters.ToList().ForEach(x => obj.SetProperty(x.Key, x.Value));

        return Hwdtech.IoC.Resolve<ICommand>("Game.Command." + message.TypeCommand, obj);
    }
}
