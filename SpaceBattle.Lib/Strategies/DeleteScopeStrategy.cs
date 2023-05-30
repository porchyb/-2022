using Accord.MachineLearning.DecisionTrees;
using SpaceBattle.Lib.Commands;
using System.ComponentModel.Design;

namespace SpaceBattle.Lib
{
    public class DeleteScopeStrategy : IStrategy
    {
        public object UseStrategy(params object[] args)
        {
            var scopeKeys = (List<string>)args[0];
            return new IoCDeleteScopeCommand(scopeKeys);
        }
    }
}
