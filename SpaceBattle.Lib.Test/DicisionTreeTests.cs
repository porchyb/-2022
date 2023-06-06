namespace SpaceBattle.Lib.Test;
using Accord.MachineLearning.DecisionTrees;
using Moq;
using Xunit;

public class DecisionTreeTests{

    [Fact]
    public void CollisionTree_SimilarCoords_True(){
        Vector pos1 = new Vector(73,22);
        Vector pos2 = new Vector(72,23);
        float[] input = pos1.vector.Concat(pos2.vector).ToArray();

        new InitTreeCommand().Execute();
        int result = IoC.Resolve<DecisionTree>("Game.CollisionTree").Decide(input);
        Assert.Equal(result, 1);
    }

    [Fact]
    public void CollisionTree_DifferentCoords_False(){
        Vector pos1 = new Vector(73,22);
        Vector pos2 = new Vector(10,70);
        float[] input = pos1.vector.Concat(pos2.vector).ToArray();

        new InitTreeCommand().Execute();
        int result = IoC.Resolve<DecisionTree>("Game.CollisionTree").Decide(input);
        Assert.Equal(result, 0);
    }
}
