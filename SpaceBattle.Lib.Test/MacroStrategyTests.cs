namespace SpaceBattle.Lib.Test;
using Moq;
using Xunit;

public class MacroStrategyTests{
    public MacroStrategyTests(){
    }

    [Fact]
    public void MacroStrategy_Name_MacroCommand(){
        Queue<ICommand> queue = new();
        Mock<IStrategy> mockQueueStrategy = new();
        mockQueueStrategy.Setup(a=>a.UseStrategy(It.IsAny<object[]>())).Returns(queue);
        IoC.Resolve<ICommand>("IoC.Add", "Game.Queue", mockQueueStrategy.Object).Execute();

        Mock<IStrategy> mockGetCommand1Strategy = new();
        Mock<ICommand> command1 = new();
        command1.Setup(a=>a.Execute()).Verifiable();
        mockGetCommand1Strategy.Setup(a=>a.UseStrategy(It.IsAny<object[]>())).Returns(command1.Object);
        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.Command1", mockGetCommand1Strategy.Object).Execute();

        Mock<IStrategy> mockGetCommand2Strategy = new();
        Mock<ICommand> command2 = new();
        command2.Setup(a=>a.Execute()).Verifiable();
        mockGetCommand2Strategy.Setup(a=>a.UseStrategy(It.IsAny<object[]>())).Returns(command2.Object);
        IoC.Resolve<ICommand>("IoC.Add", "Game.Commands.Command2", mockGetCommand2Strategy.Object).Execute();

        Mock<IStrategy> mockGetListStrategy = new();
        mockGetListStrategy.Setup(a=>a.UseStrategy(It.IsAny<object[]>())).Returns(new List<string>(new string[]{"Game.Commands.Command1", "Game.Commands.Command2"}));
        IoC.Resolve<ICommand>("IoC.Add", "Game.Macros.CompositeCommand", mockGetListStrategy.Object).Execute();


        Mock<object> mockObject = new();
        MacroStrategy macroStrategy = new();
        MacroCommand macroCommand = (MacroCommand)macroStrategy.UseStrategy("Game.Macros.CompositeCommand", mockObject.Object);
        macroCommand.Execute();

        command1.VerifyAll();
        command2.VerifyAll();
    }
}
