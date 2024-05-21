using Xunit;
using Moq;
using System;
using System.IO;
using System.Collections.Generic;
using Hwdtech.Ioc;
using Hwdtech;

namespace SpaceBattle.Lib.Test
{
    public class StartServerCommandTests
    {
        public StartServerCommandTests()
        {
            new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set",
            Hwdtech.IoC.Resolve<object>("Scopes.New", Hwdtech.IoC.Resolve<object>("Scopes.Root"))
        ).Execute();
        }

    
    [Fact]
    public void SuccessfulStartingServer()
    {
        var numberOfThreads = 5;
        var mockCommand = new Mock<Hwdtech.ICommand>(); // 1
        mockCommand.Setup(c => c.Execute()).Verifiable();

        Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Server.Thread.CreateAndStartThread", (object[] args) => mockCommand.Object).Execute();
        Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Server.StartServer", (object[] args) => new StartServerCommand((int)args[0])).Execute(); //2

        mockCommand.Verify(c => c.Execute(), Times.Never());

        Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Server.StartServer", numberOfThreads).Execute(); // 3

        mockCommand.Verify(c => c.Execute(), Times.Exactly(numberOfThreads));
    }
}
}
