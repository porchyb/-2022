using System;
using SpaceBattle;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test
{
    public class RotateCommandTest{
        [Fact]
        public void angle_from45_to135()
        {
            Mock<IRotatable> RotatableMock = new();
            RotatableMock.Setup(obj => obj.direction).Returns(new degree(45)).Verifiable();            
            RotatableMock.Setup(obj => obj.angle).Returns(90).Verifiable();

            new RotateCommand(RotatableMock.Object).Execute();

            RotatableMock.VerifySet(obj=>obj.direction = new degree(135), Times.Once);
            RotatableMock.VerifyAll();
        }
    }
}