namespace SpaceBattle.Lib.Test;
using Moq;
using Xunit;

public class CheckCollisionTests{
    [Fact]
    public void Resolve_String_Execute(){
        Mock<IMovable> mockShip1 = new();
        Mock<IMovable> mockShip2 = new();
        mockShip1.Setup(a=>a.position).Returns(new Vector(73,21));
        mockShip2.Setup(a=>a.position).Returns(new Vector(72,22));
        new InitTreeCommand().Execute();
        CheckCollisionCommand command = new CheckCollisionCommand(mockShip1.Object,mockShip2.Object);
        Assert.Throws<Exception>(() => command.Execute());
    }

    [Fact]
    public void Resolve_String_Execute_2(){
        Mock<IMovable> mockShip1 = new();        
        Mock<IMovable> mockShip2 = new();
        mockShip1.Setup(a=>a.position).Returns(new Vector(15,88));
        mockShip2.Setup(a=>a.position).Returns(new Vector(9,54));
        new InitTreeCommand().Execute();
        CheckCollisionCommand command = new CheckCollisionCommand(mockShip1.Object,mockShip2.Object);
        
    }
}
