using System;
using SpaceBattle;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test
{
    public class RotateCommandTest{
        [Fact]
        public void angle_from45_to135_confirm()
        {
            Mock<IRotatable> RotatableMock = new();
            RotatableMock.Setup(obj => obj.direction).Returns(new degree(45)).Verifiable();            
            RotatableMock.Setup(obj => obj.angle).Returns(new degree(90)).Verifiable();
            new RotateCommand(RotatableMock.Object).Execute();
            RotatableMock.VerifySet(obj=>obj.direction = new degree(135), Times.Once);
            RotatableMock.VerifyAll();
            }

        [Fact]
        public void noAngle_error()
        {
            Mock<IRotatable> RotatableMock = new();
            RotatableMock.Setup(obj => obj.direction).Returns(new degree(45)).Verifiable();
            RotateCommand rotateCommand = new RotateCommand(RotatableMock.Object);            
            Assert.Throws<NullReferenceException>(() => rotateCommand.Execute());
        }

        [Fact]
        public void noDirection_error()
        {
            Mock<IRotatable> RotatableMock = new();
            RotatableMock.Setup(obj => obj.angle).Returns(new degree (90)).Verifiable();
            RotateCommand rotateCommand = new RotateCommand(RotatableMock.Object);            
            Assert.Throws<NullReferenceException>(() => rotateCommand.Execute());
        }
    }    
}
