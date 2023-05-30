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
        public void ExceptionHandler_DefaultStrategy()
        {
            Mock<ICommand> mockCommand = new();
            var ex = new Exception();
            var strategy = IoC.Resolve<IStrategy>("Handler.Handle", mockCommand.Object, ex);
            Assert.Throws<Exception>(() => strategy.UseStrategy());
        }
        [Fact]
        public void ExceptionHandler_NotDefaultStrategy()
        {
            Mock<ICommand> mockCommand = new();
            var ex = new Exception();

            Mock<IStrategy> mockStrategy = new();
            mockStrategy.Setup(a => a.UseStrategy()).Throws(new DivideByZeroException()); //only for test

            Mock<IStrategy> mockGetStrategy = new();
            mockGetStrategy.Setup(a => a.UseStrategy()).Returns(mockStrategy.Object);

            var handlerStrategies = new Dictionary<Type, Dictionary<Exception, IStrategy>>()
            {
                {
                    mockCommand.Object.GetType(), new Dictionary<Exception, IStrategy>{ {ex, mockStrategy.Object } } 
                }
            };
            IoC.Resolve<ICommand>("IoC.Add", "Handler.Strategies", new GetExceptionStrategies(handlerStrategies)).Execute();

            
            var strategy = IoC.Resolve<IStrategy>("Handler.Handle", mockCommand.Object, ex);
            Assert.Throws<DivideByZeroException>(() => strategy.UseStrategy());
        }
    }
}
