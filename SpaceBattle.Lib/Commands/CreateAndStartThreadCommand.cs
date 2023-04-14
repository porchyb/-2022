namespace SpaceBattle.Lib;
using System.Collections.Concurrent;

public class CreateAndStartThreadCommand : ICommand{
    int id;
    Action action = () => {};
    public CreateAndStartThreadCommand(int _id, Action? _action = null){
        if(!(_action is null)){
            action = _action;
        }
        id = _id;
    }
    public void Execute(){
        try{
            IReceiver receiver = IoC.Resolve<IReceiver>("Game.Receiver");
            ISender sender = IoC.Resolve<ISender>("Game.Sender");
            MyThread thread = new MyThread(receiver, sender);
            var dict = IoC.Resolve<ConcurrentDictionary<int, MyThread>>("Game.ThreadDictionary");
            dict[id] = thread;
            //IoC.Resolve<ICommand>("IoC.Add", "Game.ThreadDictionary", dict).Execute();
            action();
        }
        catch(Exception e){
            throw e;
        }
    }
}