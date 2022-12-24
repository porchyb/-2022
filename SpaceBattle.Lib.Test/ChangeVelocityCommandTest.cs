using System;
using SpaceBattle;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test
{
    public class ChangeVelocityCommandTests
    {
        [Fact]
        public void Execute_Void_Success(){
            Mock<IMovable> mockMovable = new();

            new ChangeVelocityCommand(mockMovable.Object, new Vector(1,2)).Execute();

            mockMovable.VerifySet(a=>a.velocity=new Vector(1,2));
        }
    }
}
