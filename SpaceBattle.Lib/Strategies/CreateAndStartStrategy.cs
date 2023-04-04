namespace SpaceBattle.Lib;
using Accord.MachineLearning.DecisionTrees;

public class CreateAndStartThreadStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        int id = (int)args[0];
        Action action = args.Length>1 ? (Action)args[1] : null;
        return !(action is null)
            ? new CreateAndStartThreadCommand(id, action)
            : new CreateAndStartThreadCommand(id);
    }
}
