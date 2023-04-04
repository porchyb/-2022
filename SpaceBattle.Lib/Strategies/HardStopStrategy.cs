namespace SpaceBattle.Lib;
using Accord.MachineLearning.DecisionTrees;

public class HardStopStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        int id = (int)args[0];
        Action action = args.Length > 1 ? (Action)args[1] : null;
        return !(action is null)
            ? new ThreadHardStopCommand(id, action)
            : new ThreadHardStopCommand(id);
    }
}
