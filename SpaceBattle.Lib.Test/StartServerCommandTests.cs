using Xunit;
using Moq;
using System;
using System.IO;
using System.Collections.Generic;
using Hwdtech;

namespace SpaceBattle.Lib.Test
{
    public class StartServerCommandTests
    {
        public StartServerCommandTests()
        {
            new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();
            var scope = IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"));
            IoC.Resolve<ICommand>("Scopes.Current.Set", scope).Execute();
        }

    
    [Fact]
    public void SuccessfulStartingServer()
    {
        var numberOfThreads = 5;
        var mockCommand = new Mock<ICommand>();
        mockCommand.Setup(c => c.Execute()).Verifiable();

        IoC.Resolve<ICommand>("IoC.Register", "Server.Thread.CreateAndStartThread", (object[] args) => mockCommand.Object).Execute();
        IoC.Resolve<ICommand>("IoC.Register", "Server.StartServer", (object[] args) => new StartServerCommand((int)args[0])).Execute();

        mockCommand.Verify(c => c.Execute(), Times.Never());

        IoC.Resolve<ICommand>("Server.Start", numberOfThreads).Execute();

        mockCommand.Verify(c => c.Execute(), Times.Exactly(numberOfThreads));
    }
}
}
