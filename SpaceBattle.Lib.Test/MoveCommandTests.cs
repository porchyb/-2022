using System;
using SpaceBattle;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test
{
    public class MoveCommandTest
    {
        [Fact]
        public void MoveCommand_Pos1_Pos2()
        {
            //Arrange
            Mock<IMovable> MovableMock = new();
            MovableMock.Setup(obj => obj.position).Returns(new Vector(12,5)).Verifiable();
            MovableMock.Setup(obj => obj.velocity).Returns(new Vector(-7,3)).Verifiable();

            //Act
            new MoveCommand(MovableMock.Object).Execute();

            //Assert
            MovableMock.VerifySet(obj=>obj.position = new Vector(5, 8), Times.Once);
            MovableMock.VerifyAll();
        }

        [Fact]
        public void MoveCommand_NoPosition_Error()
        {
            //Arrange
            Mock<IMovable> MovableMock = new();
            MovableMock.Setup(obj => obj.velocity).Returns(new Vector(-7, 3)).Verifiable();

            //Act
            MoveCommand mCommand = new MoveCommand(MovableMock.Object);

            //Assert
            Assert.Throws<ArgumentException>(() => mCommand.Execute());
        }
    }
}
