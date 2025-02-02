using System.Numerics;
using Moq;
using Otus_Task_2.Interface;
using Otus_Task_2.Move;

namespace TestProject1;

[TestFixture]
public class LinearMovementTests
{
    [Test]
    public void Move_ValidObject_ChangesPosition()
    {
        var mockMovable = new Mock<IMovable>();
        mockMovable.SetupProperty(m => m.Position, new Otus_Task_2.Vector(12, 5));
        mockMovable.SetupGet(m => m.Velocity).Returns(new Otus_Task_2.Vector(-7, 3));
        var mover = new LinearMovement();
        
        mover.Move(mockMovable.Object);
        
        Assert.AreEqual(new Otus_Task_2.Vector(5, 8), mockMovable.Object.Position);
    }

    [Test]
    public void Move_WhenPositionUnreadable_Throws()
    {
        var mockMovable = new Mock<IMovable>();
        mockMovable.SetupGet(m => m.Position).Throws<InvalidOperationException>();
        var mover = new LinearMovement();
        
        Assert.Throws<InvalidOperationException>(() => mover.Move(mockMovable.Object));
    }

    [Test]
    public void Move_WhenVelocityUnreadable_Throws()
    {
        var mockMovable = new Mock<IMovable>();
        mockMovable.SetupGet(m => m.Velocity).Throws<InvalidOperationException>();
        var mover = new LinearMovement();
        
        Assert.Throws<InvalidOperationException>(() => mover.Move(mockMovable.Object));
    }

    [Test]
    public void Move_WhenPositionNotSettable_Throws()
    {
        var mockMovable = new Mock<IMovable>();
        mockMovable.SetupSet(m => m.Position = It.IsAny<Otus_Task_2.Vector>()).Throws<InvalidOperationException>();
        var mover = new LinearMovement();
        
        Assert.Throws<InvalidOperationException>(() => mover.Move(mockMovable.Object));
    }
}