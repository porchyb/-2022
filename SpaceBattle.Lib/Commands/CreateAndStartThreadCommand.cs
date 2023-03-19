namespace SpaceBattle.Lib;

class CreateAndStartThreadCommand : ICommand{
    Action action;
    public CreateAndStartThreadCommand(int id, Action? _action = null){
        if(!(action is null)){
            action = _action;
        }
    }
    public void Execute(){
        try{
            MyThread thread = new MyThread(IoC.Resolve<IReceiver>("Game.Receiver"));
            action();
        }
        catch(Exception e){
            throw e;
        }
    }
}