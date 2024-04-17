using Xunit;
using Moq;
using System;
using System.IO;
using System.Collections.Generic;
using Hwdtech;

namespace SpaceBattle.Lib.Test
{
    public class StopServerCommandTests
    {
        public StopServerCommandTests()
        {
            new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();
            var scope = IoC.Resolve<object>("Scopes.New", IoC.Resolve<object>("Scopes.Root"));
            IoC.Resolve<ICommand>("Scopes.Current.Set", scope).Execute();
            IoC.Resolve<ICommand>("IoC.Register", "Thread.GetDictionary", (object[] args) => {
                Dictionary<string, string> threads = new Dictionary<string, string>() {
                {"1", "Thread1"},
                {"2", "Thread2"},
                {"3", "Thread3"}
            };
                return threads;
            }).Execute();
        }

        [Fact]
        public void StopThreadTest()
        {
            Dictionary<string, string> myThreads = IoC.Resolve<Dictionary<string, string>>("Thread.GetDictionary");
            var mockCommand = new Mock<ICommand>();
            IoC.Resolve<ICommand>("IoC.Register", "Thread.SoftStopTheThreads", (object[] args) => mockCommand.Object).Execute();
            IoC.Resolve<ICommand>("IoC.Register", "Server.StopServer", (object[] args) => new StopServerCommand()).Execute();
            mockCommand.Verify(c => c.Execute(), Times.Never());
            IoC.Resolve<ICommand>("Thread.Server.StopServer").Execute();
            mockCommand.Verify(c => c.Execute(), Times.Exactly(3));
        }
    }
}
