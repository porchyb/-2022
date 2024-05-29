using Hwdtech;
namespace SpaceBattle.Lib
{
public class InterpretCommand : Hwdtech.ICommand
{
    IInterpretingMessage message;

    public InterpretCommand(IInterpretingMessage message) => this.message = message;

    public void Execute()
    {
        var cmd = Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Game.Command.Create.FromMessage", this.message);

            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Game.Queue.Push", this.message.GameID, cmd).Execute();
        }
    }
}
