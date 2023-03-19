namespace SpaceBattle.Lib;

public class ThreadHardStopCommand: ICommand{
    MyThread stoppingThread;
    public ThreadHardStopCommand(MyThread _thread){
        stoppingThread = _thread;
    }
    public void Execute(){
        try{
            stoppingThread.Stop();
        }
        catch(Exception e){
            throw e;
        }
    }
}
public class ThreadSoftStopCommand: ICommand{
    MyThread stoppingThread;
    public ThreadSoftStopCommand(MyThread _thread){
        stoppingThread = _thread;
    }
    public void Execute(){
        try{
            stoppingThread.queue.Put(new ThreadHardStopCommand(stoppingThread));
        }
        catch(Exception e){
            throw e;
        }
    }
}