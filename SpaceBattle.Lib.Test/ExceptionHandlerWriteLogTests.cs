using Xunit;
using Moq;
using System;
using System.IO;
using System.Collections.Generic;
using Hwdtech;

namespace SpaceBattle.Lib.Test
{
    public class ExceptionHandlerWriteLogTests
    {
        [Fact]
        public void SuccessExceptionHandlerWriteLogTests()
        {
            SpaceBattle.ICommand command = Mock.Of<SpaceBattle.ICommand>();
            Exception exception = new Exception("Test exception");
            string logFileName = "error.log";
            string errorMessage = $"Error in command '{command.GetType().Name}': {exception.Message}";

            var strategy = new ExceptionHandlerStrategy();

            strategy.UseStrategy(command, exception);

            Assert.True(File.Exists(logFileName));
            string[] lines = File.ReadAllLines(logFileName);
            Assert.Contains(errorMessage, lines[0]);
        }
    }
}
