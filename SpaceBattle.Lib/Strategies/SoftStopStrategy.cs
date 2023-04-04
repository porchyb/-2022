namespace SpaceBattle.Lib;
using Accord.MachineLearning.DecisionTrees;

public class SoftStopStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        int id = (int)args[0];
        Action action = args.Length > 1 ? (Action)args[1] : null;
        return !(action is null)
            ? new ThreadSoftStopCommand(id, action)
            : new ThreadSoftStopCommand(id);
    }
}
