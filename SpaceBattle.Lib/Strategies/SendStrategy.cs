namespace SpaceBattle.Lib;
using Accord.MachineLearning.DecisionTrees;

public class SendStrategy: IStrategy{
    public object UseStrategy(params object[] args){
        int id = (int)args[0];
        ICommand cmd = (ICommand)args[1];
        return new SendCommand(id, cmd);
    }
}
