namespace SpaceBattle.Lib;
using System.Collections.Concurrent;

public class ThreadHardStopCommand: ICommand{
    int id;
    Action action;
    public ThreadHardStopCommand(int _id, Action? _action = null){
        if(!(action is null)){
            action = _action;
        }
        id = _id;
    }
    public void Execute(){
        try{
            MyThread thread = IoC.Resolve<ConcurrentDictionary<int, MyThread>>("Game.ThreadDictionary")[id];
            thread.Stop();
        }
        catch(Exception e){
            throw e;
        }
    }
}
public class ThreadSoftStopCommand: ICommand{
    int id;
    Action action;
    public ThreadSoftStopCommand(int _id, Action? _action = null){
        if(!(action is null)){
            action = _action;
        }
        id = _id;
    }
    public void Execute(){
        try{
            new SendCommand(id, new ThreadHardStopCommand(id, action)).Execute();
        }
        catch(Exception e){
            throw e;
        }
    }
}