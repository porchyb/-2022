namespace SpaceBattle.Lib.Test;
using Moq;
using Xunit;

public class StartMoveCommandTests{
    public StartMoveCommandTests(){
        Mock<ICommand> mockCommand = new();
        mockCommand.Setup(a=>a.Execute());

        Mock<IStrategy> mockQueueStrategy = new();
        mockQueueStrategy.Setup(a=>a.UseStrategy()).Returns(new Queue<ICommand>());
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue", mockQueueStrategy.Object).Execute();
    }

    [Fact]
    public void Execute_Void_Success(){
        Mock<IMoveStartable> mockStartable = new();
        Mock<IMovable> mockMovable = new();
        mockStartable.Setup(a=>a.target).Returns(mockMovable.Object).Verifiable();

        new StartMoveCommand(mockStartable.Object, new Vector(1,2)).Execute();

        mockStartable.VerifyAll();
    }
}