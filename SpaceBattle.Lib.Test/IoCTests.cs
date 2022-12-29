namespace SpaceBattle.Lib.Test;
using Moq;
using Xunit;

public class IoCTests{
    /*public IoCTests(){
        Mock<ICommand> mockCommand = new();
        mockCommand.Setup(a=>a.Execute());

        Mock<IStrategy> mockStrategy = new();
        mockStrategy.Setup(a=>a.UseStrategy()).Returns(It.IsAny<ICommand>);
        IoC.Resolve<ICommand>("IoC.Add", "Game.TestStrategy", mockStrategy).Execute();
    }*/

    [Fact]
    public void Resolve_String_Execute(){
        Mock<ICommand> mockCommand = new();
        mockCommand.Setup(a=>a.Execute()).Verifiable();
        Mock<IStrategy> mockStrategy = new();
        mockStrategy.Setup(a=>a.UseStrategy()).Returns(mockCommand.Object);
        IoC.Resolve<ICommand>("IoC.Add", "Game.TestStrategy", mockStrategy.Object).Execute();

        IoC.Resolve<ICommand>("Game.TestStrategy").Execute();

        mockCommand.Verify(a=>a.Execute());
    }
}
