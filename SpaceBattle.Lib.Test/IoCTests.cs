namespace SpaceBattle.Lib.Test;
using Moq;
using Xunit;
using System.Collections;

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
    [Fact]
    public void SetScope_Dictionary_Execute(){
        Mock<ICommand> mockCommand1 = new();
        Mock<IStrategy> mockStrategy1 = new();
        mockStrategy1.Setup(a=>a.UseStrategy()).Returns(mockCommand1.Object);
        var scope = new Dictionary<string, IStrategy>{
            {"Game.TestCommand1", mockStrategy1.Object}
        };

        ICommand cmd = new IoCSetScopeCommand(scope);
        cmd.Execute();
        
        Assert.Equal(mockCommand1.Object, IoC.Resolve<ICommand>("Game.TestCommand1"));
    }
    [Fact]
    public void DeleteScopeWithList_Dictionary_Execute()
    {
        Mock<ICommand> mockCommand = new();
        Mock<IStrategy> mockStrategy = new();
        mockStrategy.Setup(a => a.UseStrategy()).Returns(mockCommand.Object);
        IoC.Resolve<ICommand>("IoC.Add", "Game.Strategy", mockStrategy.Object).Execute();

        var removedKeys = new List<string>() { "Game.Strategy" };

        ICommand cmd = new IoCDeleteScopeCommand(removedKeys);
        cmd.Execute();

        
        Assert.Throws<KeyNotFoundException>(() => IoC.Resolve<ICommand>("Game.Strategy"));
    }
}
