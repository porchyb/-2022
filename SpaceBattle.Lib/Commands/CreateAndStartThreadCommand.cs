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
            IReceiver receiver = IoC.Resolve<IReceiver>("Game.Receiver");
            ISender sender = IoC.Resolve<ISender>("Game.Sender");
            MyThread thread = new MyThread(receiver, sender);
            action();
        }
        catch(Exception e){
            throw e;
        }
    }
}