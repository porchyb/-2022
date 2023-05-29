using Hwdtech;
using Moq;
using SpaceBattle.Lib.Commands;
using System;
using Xunit;

namespace SpaceBattle.Lib.Test
{
    public class ExceptionHandlerTests
    {
        public ExceptionHandlerTests()
        {
            var handlerStrategies = new Dictionary<Type, Dictionary<Exception, IStrategy>>();
            IoC.Resolve<ICommand>("IoC.Add", "Handler.Handle", new ExceptionHandlerStrategy()).Execute();
            IoC.Resolve<ICommand>("IoC.Add", "Handler.Strategies", new GetExceptionStrategies(handlerStrategies)).Execute();
            IoC.Resolve<ICommand>("IoC.Add", "Handler.Default", new GetExceptionHandlerDefaultStrategy()).Execute();
        }

        [Fact]
        public void ExceptionHandler_()
        {
            Mock<ICommand> mockCommand = new();
            var ex = new Exception();
            var strategy = IoC.Resolve<IStrategy>("Handler.Handle", mockCommand.Object, ex);
            Assert.Throws<Exception>(() => strategy.UseStrategy());
        }
    }
}
