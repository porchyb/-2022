using Accord.MachineLearning.DecisionTrees;
namespace SpaceBattle.Lib;

public class CheckCollisionCommand: ICommand{
    private IMovable obj1;
    private IMovable obj2;
    public CheckCollisionCommand(IMovable obj1, IMovable obj2){
        this.obj1 = obj1;
        this.obj2 = obj2;
    }
    public void Execute(){
        float[] input = obj1.position.vector.Concat(obj2.position.vector).ToArray();
        bool isCollision = Convert.ToBoolean(IoC.Resolve<DecisionTree>("Game.CollisionTree").Decide(input));
        if(isCollision) throw new Exception();
    }
}
