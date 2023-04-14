using System;
using SpaceBattle;
using Xunit;
using Moq;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib.Test
{
    public class ExceptionHandlerTests
    {
        [Fact]
        public void Handle_Void_Success()
        {
            Mock<Exception> exception = new();
            Mock<ICommand> command = new();

            ExceptionHandler.Handle(exception.Object, command.Object);

            Assert.True(true);
        }
    }
}
