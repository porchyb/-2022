using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

public class SendCommand : ICommand{
    ICommand command;
    int id;
    MyThread thread;
    public SendCommand(int _id, ICommand _command){
        command = _command;
        id = _id;
    }
    public void Execute(){
        try{
            var dict = IoC.Resolve<ConcurrentDictionary<int, MyThread>>("Game.ThreadDictionary");
            thread = dict[id];
            thread.sender.Send(command);
        }
        catch(Exception e){
            throw e;
        }
    }
}