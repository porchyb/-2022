using Xunit;
using Moq;
using System;
using System.IO;
using System.Collections.Generic;
using Hwdtech;
using Hwdtech.Ioc;

namespace SpaceBattle.Lib.Test
{
    public class ExceptionHandlerWriteLogTests
    {
        [Fact]
        public void SuccessExceptionHandlerWriteLogTests()
        {
            Hwdtech.ICommand command = Mock.Of<Hwdtech.ICommand>();
            Exception exception = new Exception("Test exception");
            string logFileName = "error.log";
            string errorMessage = $"Error in command '{command.GetType().Name}': {exception.Message}";

            var strategy = new ExceptionHandlerWriteLogStrategy();

            strategy.UseStrategy(command, exception);

            Assert.True(File.Exists(logFileName));
            string[] lines = File.ReadAllLines(logFileName);
            Assert.Contains(errorMessage, lines[0]);
        }
    }
}
