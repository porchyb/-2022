namespace SpaceBattle.Lib.Test;
using Moq;
using System.Collections.Generic;
using Hwdtech;
using Xunit;

public class GameProcessingTests
{
    public GameProcessingTests()
    {
        new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();
        var scope = Hwdtech.IoC.Resolve<object>("Scopes.New", Hwdtech.IoC.Resolve<object>("Scopes.Root"));
        Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", scope).Execute();

        Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Game.GetTick", (object[] args) =>
        {
            return (object)100;
        }).Execute();
    }
    [Fact]
    public void Test_GameObjectsDeleteGet()
    {
        string gameItemId = "item1";
        var obj = new object();
        var objects = new Dictionary<string, object>()
        {
            { gameItemId, obj }
        };

        var result = new GetGameObjectStrategy().UseStrategy(objects, gameItemId);
        Assert.Equal(obj, result);

        new DeleteGameObjectCommand(objects, gameItemId).Execute();
        Assert.DoesNotContain(gameItemId, objects.Keys);
    }
    [Fact]
    public void Test_GameQueuePushAndPop()
    {
        var commandMock = new Mock<Hwdtech.ICommand>();
        var commandQueueMock = new Mock<Queue<Hwdtech.ICommand>>();

        new GameQueuePushCommand(commandQueueMock.Object, commandMock.Object).Execute();
        Assert.True(commandQueueMock.Object.Contains(commandMock.Object));

        var command = new GameQueuePopStrategy().UseStrategy(commandQueueMock.Object);
        Assert.Equal(command, commandMock.Object);
    }
}
