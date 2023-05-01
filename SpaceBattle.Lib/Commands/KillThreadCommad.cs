namespace SpaceBattle.Lib;
using System.Collections.Concurrent;

public class KillThreadCommand: ICommand{
    int id;
    Action action = ()=>{};
    public KillThreadCommand(int _id, Action? _action = null){
        if(!(_action is null)){
            action = _action;
        }
        id = _id;
    }
    public void Execute(){
        ConcurrentDictionary<int, MyThread> dict = IoC.Resolve<ConcurrentDictionary<int, MyThread>>("Game.ThreadDictionary");
            MyThread thread = dict[id];
            thread.Kill();
            if(dict.TryRemove(id, out _)){
                action();
            }
            else{
                throw new ArgumentException();
            }
        try{
        }
        catch(Exception e){
            throw e;
        }
    }
}
