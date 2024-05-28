using Hwdtech;
namespace SpaceBattle.Lib;

public class DeleteGameCommand : Hwdtech.ICommand
{
    private string gameId;
    public DeleteGameCommand(string gameId)
    {
        this.gameId = gameId;
    }
    public void Execute()
    {
        Dictionary<string, object> scopeMap = Hwdtech.IoC.Resolve<Dictionary<string, object>>("Game.ScopeMap");
        scopeMap.Remove(gameId);
    }
}
