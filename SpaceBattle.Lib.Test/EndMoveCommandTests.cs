namespace SpaceBattle.Lib.Test;
using Moq;
using Xunit;

public class EndMoveCommandTests{
    public EndMoveCommandTests(){        
        Mock<IStrategy> mockQueueStrategy = new();
        mockQueueStrategy.Setup(a=>a.UseStrategy()).Returns(new Queue<ICommand>());
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue", mockQueueStrategy.Object).Execute();
    }
    [Fact]
    public void ExecuteSuccess(){
        // v endMoveC ya isp IMoveEndable
        //Mock<EndMoveCommand> mockEndable = new();
        
        // Mock<IMoveEndable> mockIEndable = new();
        // mockEndable.Setup(a=>a.obje).Returns(mockIEndable.Object).Verifiable();

        // new EndMoveCommand(mockIEndable.Object).Execute();
        // mockEndable.VerifyAll();

        Mock<IMoveEndable> mockIEndable = new();
        Mock<IMovable> mockMovable = new();
        mockIEndable.Setup(a=>a.target).Returns(mockMovable.Object).Verifiable();
        new EndMoveCommand(mockIEndable.Object).Execute();
        mockIEndable.VerifyAll();
        }
}
