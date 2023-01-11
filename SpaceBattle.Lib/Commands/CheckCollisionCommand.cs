using Accord.MachineLearning.DecisionTrees;
namespace SpaceBattle.Lib;

public class CheckCollisioCommand: ICommand{
    private IMovable obj1;
    private IMovable obj2;
    public CheckCollisionCommand(IMovable _obj1, IMovable _obj2){
        this.obj1 = _obj1;
        this.obj2 = _obj2;
    }
    public void Execute(){
        float[][] input = obj1.position + obj2.position;
        return IoC.Resolve<DecisionTree>("Game.CollisionTree").Decide(input);
    }
}
