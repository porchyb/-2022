namespace SpaceBattle.Lib;


public class ActionCommand : Hwdtech.ICommand
{
    private Action action;

    public ActionCommand(Action action)
    {
        this.action = action;
    }

    public void Execute() => this.action();
}
