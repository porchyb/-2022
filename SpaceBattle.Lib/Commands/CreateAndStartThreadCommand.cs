namespace SpaceBattle.Lib;

class CreateAndStartThreadCommand : ICommand{
    Action action = () => {};
    public CreateAndStartThreadCommand(int id, params object[] _action){
        if(!(_action.Length > 0)){
            action = (Action)_action[0];
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