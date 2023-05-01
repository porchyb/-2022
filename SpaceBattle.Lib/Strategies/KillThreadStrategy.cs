namespace SpaceBattle.Lib;

public class KillThreadStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        int id = (int)args[0];
        Action? action = args.Length > 1 ? (Action)args[1] : null;
        return !(action is null)
            ? new KillThreadCommand(id, action)
            : new KillThreadCommand(id);
    }
}
