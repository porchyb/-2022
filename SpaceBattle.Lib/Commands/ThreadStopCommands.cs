namespace SpaceBattle.Lib;
using System.Collections.Concurrent;

public class ThreadHardStopCommand: ICommand{
    int id;
    Action action = ()=>{};
    public ThreadHardStopCommand(int _id, Action? _action = null){
        if(!(_action is null)){
            action = _action;
        }
        id = _id;
    }
    public void Execute(){
        try{
            MyThread thread = IoC.Resolve<ConcurrentDictionary<int, MyThread>>("Game.ThreadDictionary")[id];
            thread.Stop();
            action();
        }
        catch(Exception e){
            throw e;
        }
    }
}
public class ThreadSoftStopCommand: ICommand{
    int id;
    Action action = () => {};
    public ThreadSoftStopCommand(int _id, params object[] _action){
        if(_action.Length>0){
            action = (Action)_action[0];
        }
        id = _id;
    }
    public void Execute(){
        try{
            new SendCommand(id, new ThreadHardStopCommand(id, action)).Execute();
            action();
        }
        catch(Exception e){
            throw e;
        }
    }
}
