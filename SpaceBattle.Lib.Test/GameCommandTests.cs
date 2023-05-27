using Moq;
using SpaceBattle.Lib.Commands;
using System;
using Xunit;

namespace SpaceBattle.Lib.Test
{
    public class GameCommandTests
    {
        public GameCommandTests()
        {
            IoC.Resolve<ICommand>("IoC.Add", "IoC.SetScopeCommand", new SetScopeStrategy()).Execute();
            IoC.Resolve<ICommand>("IoC.Add", "IoC.DeleteScopeCommand", new DeleteScopeStrategy()).Execute();
        }

        [Fact]
        public void GameCommand_Id_Success()
        {
            Mock<ICommand> mockCommand = new();
            mockCommand.Setup(a => a.Execute()).Verifiable();
            Queue<ICommand> gameQueue = new() { };
            gameQueue.Enqueue(mockCommand.Object);
            Mock<IStrategy> mockQueueStrategy = new();
            mockQueueStrategy.Setup(a => a.UseStrategy()).Returns(gameQueue);

            Mock<IStrategy> mockTimeQuantumStrategy = new();
            mockTimeQuantumStrategy.Setup(a => a.UseStrategy()).Returns(500);

            var gameScope = new Dictionary<string, IStrategy>{
                {"Game.TimeQuantum", mockTimeQuantumStrategy.Object},
                {"Game.Queue", mockQueueStrategy.Object}
            };
            var gameScopes = new Dictionary<int, Dictionary<string, IStrategy>>{
                {1, gameScope}
            };
            Mock<IStrategy> mockGameScopesStrategy = new();
            mockGameScopesStrategy.Setup(a=>a.UseStrategy(It.IsAny<object[]>())).Returns(gameScopes);
            IoC.Resolve<ICommand>("IoC.Add", "IoC.GameScopes", mockGameScopesStrategy.Object).Execute();

            new GameCommand(1).Execute();

            Assert.True(gameQueue.Count == 0);
        }

        [Fact]
        public void GameCommand_Id_CommandException()
        {
            Mock<ICommand> mockCommand = new();
            mockCommand.Setup(a => a.Execute()).Throws(new Exception());
            Queue<ICommand> gameQueue = new() { };
            gameQueue.Enqueue(mockCommand.Object);
            Mock<IStrategy> mockQueueStrategy = new();
            mockQueueStrategy.Setup(a => a.UseStrategy()).Returns(gameQueue);

            Mock<IStrategy> mockTimeQuantumStrategy = new();
            mockTimeQuantumStrategy.Setup(a => a.UseStrategy()).Returns(500);

            var gameScope = new Dictionary<string, IStrategy>{
                {"Game.TimeQuantum", mockTimeQuantumStrategy.Object},
                {"Game.Queue", mockQueueStrategy.Object}
            };
            var gameScopes = new Dictionary<int, Dictionary<string, IStrategy>>{
                {1, gameScope}
            };
            Mock<IStrategy> mockGameScopesStrategy = new();
            mockGameScopesStrategy.Setup(a => a.UseStrategy(It.IsAny<object[]>())).Returns(gameScopes);
            IoC.Resolve<ICommand>("IoC.Add", "IoC.GameScopes", mockGameScopesStrategy.Object).Execute();

            new GameCommand(1).Execute();
        }
    }
}
