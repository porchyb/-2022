namespace SpaceBattle.Lib.Test;
using Moq;
using Xunit;

public class MacroStrategyTests{
    public MacroStrategyTests(){
        Queue<ICommand> queue = new();

        Mock<IStrategy> mockQueueStrategy = new();
        mockQueueStrategy.Setup(a=>a.UseStrategy()).Returns(queue);
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue", mockQueueStrategy.Object).Execute();

        Mock<IStrategy> mockGetCommand1Strategy = new();
        mockGetCommand1Strategy.Setup(a=>a.UseStrategy()).Returns(new Mock<ICommand>());
        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.Command1", mockGetCommand1Strategy.Object).Execute();

        Mock<IStrategy> mockGetCommand2Strategy = new();
        mockGetCommand2Strategy.Setup(a=>a.UseStrategy()).Returns(new Mock<ICommand>());
        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.Command2", mockGetCommand2Strategy.Object).Execute();

        Mock<IStrategy> mockGetListStrategy = new();
        mockGetListStrategy.Setup(a=>a.UseStrategy()).Returns(new List<string>(new string[]{"Game.Commands.Command1", "Game.Commands.Command2"}));
        IoC.Resolve<ICommand>("IoC.Add", "Game.Macros.CompositeCommand", mockGetListStrategy.Object).Execute();
    }

    [Fact]
    public void MacroStrategy_Name_MacroCommand(){
        Mock<object> mockObject = new();
        MacroStrategy macroStrategy = new();
        MacroCommand macroCommand = (MacroCommand)macroStrategy.UseStrategy("Game.Macros.CompositeCommand", mockObject.Object);

        ICommand command1 = IoC.Resolve<ICommand>("Game.Commands.Command1", mockObject.Object);
        ICommand command2 = IoC.Resolve<ICommand>("Game.Commands.Command2", mockObject.Object);
        List<ICommand> expectedCommandList = new List<ICommand>{command1, command2};

        Assert.Equal(macroCommand.commands, expectedCommandList);
    }
}
