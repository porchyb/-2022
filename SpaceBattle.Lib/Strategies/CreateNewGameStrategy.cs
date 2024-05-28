using Accord.MachineLearning.DecisionTrees;
using SpaceBattle.Lib.Commands;
using System.ComponentModel.Design;

namespace SpaceBattle.Lib
{
    public class SetScopeStrategy : IStrategy
    {
        public object UseStrategy(params object[] args)
        {
            var scope = (Dictionary<string, IStrategy>)args[0];
            return new IoCSetScopeCommand(scope);
        }
    }
}
