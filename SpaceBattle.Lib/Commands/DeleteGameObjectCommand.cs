using Hwdtech;
namespace SpaceBattle.Lib;

public class DeleteGameObjectCommand : Hwdtech.ICommand
{
    Dictionary<string, object> objects;
    string gameItemId;
    public DeleteGameObjectCommand(Dictionary<string, object> objects, string gameItemId)
    {
        this.objects = objects;
        this.gameItemId = gameItemId;
    }
    public void Execute()
    {
        objects.Remove(gameItemId);
    }
}
