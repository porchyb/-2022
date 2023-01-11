namespace SpaceBattle.Lib;

public class GetCollisionTree: IStrategy{
    private DecisionTree tree;
    public GetCollisionTree(DecisionTree _tree){
        tree = _tree;
    }
    public object UseStrategy(params object[] args){
        
        return tree;
    }
}
