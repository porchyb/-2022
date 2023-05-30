namespace SpaceBattle.Lib;
using Accord.MachineLearning.DecisionTrees;

public class GetExceptionStrategies : IStrategy{
    private Dictionary<Type, Dictionary<Exception, IStrategy>> strategies;
    public GetExceptionStrategies(Dictionary<Type, Dictionary<Exception, IStrategy>> _strategies){
        strategies = _strategies;
    }
    public object UseStrategy(params object[] args){
        
        return strategies;
    }
}
