namespace SpaceBattle.Lib.Test;
using Moq;
using Hwdtech;
using Hwdtech.Ioc;
using System.IO;
using System.Collections.Generic;
using Xunit;

public class InterpretTests
{
    Dictionary<int, Queue<ICommand>> gameQueueMap = new Dictionary<int, Queue<ICommand>>();
    Dictionary<int, IUObject> gameUObjectMap = new Dictionary<int, IUObject>();

    public InterpretTests()
    {
        new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();

        Mock<IUObject> mockUObject = new Mock<IUObject>();
        mockUObject.Setup(x => x.SetProperty(It.IsAny<string>(), It.IsAny<object>()));

        gameQueueMap.Add(1, new Queue<ICommand>());

        gameUObjectMap.Add(1, mockUObject.Object);

        Hwdtech.IoC.Resolve<ICommand>("Scopes.Current.Set", Hwdtech.IoC.Resolve<object>("Scopes.New", Hwdtech.IoC.Resolve<object>("Scopes.Root"))).Execute();
        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.Queue.Map", (object[] args) => gameQueueMap).Execute();
        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.UObject.Map", (object[] args) => gameUObjectMap).Execute();
        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.Get.Queue", (object[] args) => new GetGameQueueStrategy().UseStrategy(args)).Execute();
        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.Get.UObject", (object[] args) => new GetGameUObjectStrategy().UseStrategy(args)).Execute();
        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.Command.Create.FromMessage", (object[] args) => new CreateGameCommandFromMessageStrategy().UseStrategy(args)).Execute();
        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.Queue.Push", (object[] args) => new GameQueuePushCommandStrategy().UseStrategy(args)).Execute();
    }

    [Fact]
    public void SuccessfulPush()
    {
        Mock<ICommand> mockCommand = new Mock<ICommand>();

        Mock<IInterpretingMessage> mockMessage = new Mock<IInterpretingMessage>();
        mockMessage.SetupGet(x => x.GameID).Returns(1);
        mockMessage.SetupGet(x => x.TypeCommand).Returns("Test");
        mockMessage.SetupGet(x => x.Parameters).Returns(new Dictionary<string, object> { { "Test", 1 } });
        mockMessage.SetupGet(x => x.ObjectID).Returns(1);

        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.Command.Test", (object[] args) => mockCommand.Object).Execute();

        var intepretcmd = new InterpretCommand(mockMessage.Object);
        intepretcmd.Execute();

        Assert.True(gameQueueMap.Count() == 1);
    }


    [Fact]
    public void GetGameQueueThrowsException()
    {
        Mock<ICommand> mockCommand = new Mock<ICommand>();

        Mock<IUObject> mockUObject = new Mock<IUObject>();
        mockUObject.Setup(x => x.SetProperty(It.IsAny<string>(), It.IsAny<object>())).Verifiable();

        Mock<IInterpretingMessage> mockMessage = new Mock<IInterpretingMessage>();
        mockMessage.SetupGet(x => x.GameID).Returns(2);
        mockMessage.SetupGet(x => x.TypeCommand).Returns("Test");
        mockMessage.SetupGet(x => x.Parameters).Returns(new Dictionary<string, object> { { "Test", 1 } });
        mockMessage.SetupGet(x => x.ObjectID).Returns(1);

        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.Command.Test", (object[] args) => mockCommand.Object).Execute();

        var intepretcmd = new InterpretCommand(mockMessage.Object);
        Assert.Throws<Exception>(() => { intepretcmd.Execute(); });
    }
    [Fact]
    public void GetGameUObjectThrowsException()
    {
        Mock<ICommand> mockCommand = new Mock<ICommand>();

        Mock<IUObject> mockUObject = new Mock<IUObject>();
        mockUObject.Setup(x => x.SetProperty(It.IsAny<string>(), It.IsAny<object>())).Verifiable();

        Mock<IInterpretingMessage> mockMessage = new Mock<IInterpretingMessage>();
        mockMessage.SetupGet(x => x.GameID).Returns(1);
        mockMessage.SetupGet(x => x.TypeCommand).Returns("Test");
        mockMessage.SetupGet(x => x.Parameters).Returns(new Dictionary<string, object> { { "Test", 1 } });
        mockMessage.SetupGet(x => x.ObjectID).Returns(2);

        Hwdtech.IoC.Resolve<ICommand>("IoC.Register", "Game.Command.Test", (object[] args) => mockCommand.Object).Execute();

        var intepretcmd = new InterpretCommand(mockMessage.Object);
        Assert.Throws<Exception>(() => { intepretcmd.Execute(); });
    }

}
