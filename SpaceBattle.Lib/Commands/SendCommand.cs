using System.Collections.Concurrent;
namespace SpaceBattle.Lib;

class SendCommand : ICommand{
    ICommand command;
    int id;
    MyThread thread;
    public SendCommand(int _id, ICommand _command){
        command = _command;
        id = _id;
    }
    public void Execute(){
        try{
            thread = IoC.Resolve<ConcurrentDictionary<int, MyThread>>("Game.ThreadDictionary")[id];
            thread.sender.Send(command);
        }
        catch(Exception e){
            throw e;
        }
    }
}