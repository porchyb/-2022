using Xunit;
using Moq;
using System;
using System.IO;
using System.Collections.Generic;
using Hwdtech;
using Hwdtech.Ioc;


namespace SpaceBattle.Lib.Test
{
    public class StopServerCommandTests
    {
        public StopServerCommandTests()
        {
            new Hwdtech.Ioc.InitScopeBasedIoCImplementationCommand().Execute();
            var scope = Hwdtech.IoC.Resolve<object>("Scopes.New", Hwdtech.IoC.Resolve<object>("Scopes.Root"));
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Scopes.Current.Set", scope).Execute();
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Thread.GetDictionary", (object[] args) => {
                Dictionary<string, string> threads = new Dictionary<string, string>() {
                {"1", "Thread1"},
                {"2", "Thread2"},
                {"3", "Thread3"}
            };
                return threads;
            }).Execute();
        }

        [Fact]
        public void StopServerTest()
        {
            Dictionary<string, string> myThreads = Hwdtech.IoC.Resolve<Dictionary<string, string>>("Thread.GetDictionary");
            var mockCommand = new Mock<Hwdtech.ICommand>();
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Thread.SoftStopTheThreads", (object[] args) => mockCommand.Object).Execute();
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("IoC.Register", "Server.StopServer", (object[] args) => new StopServerCommand()).Execute();
            //mockCommand.Verify(c => c.Execute(), Times.Never());
            Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Server.StopServer").Execute();
            mockCommand.Verify(c => c.Execute(), Times.Exactly(3));
        }
    }
}
