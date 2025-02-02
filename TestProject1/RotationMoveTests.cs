using Moq;
using Otus_Task_2.Interface;
using Otus_Task_2.Move;

namespace TestProject1;

[TestFixture]
public class RotationMoveTests
{
    [Test]
    public void Rotate_ValidObject_ChangesDirection()
    {
        var mockRotatable = new Mock<IRotatable>();
        mockRotatable.SetupProperty(r => r.Direction, 90);
        mockRotatable.SetupGet(r => r.AngularVelocity).Returns(10);
        var rotator = new RotationMove();
        
        rotator.Rotate(mockRotatable.Object);
        
        Assert.AreEqual(100, mockRotatable.Object.Direction);
    }

    [Test]
    public void Rotate_NegativeDirection_WrapsCorrectly()
    {
        var mockRotatable = new Mock<IRotatable>();
        mockRotatable.SetupProperty(r => r.Direction, 30);
        mockRotatable.SetupGet(r => r.AngularVelocity).Returns(-45);
        var rotator = new RotationMove();

        rotator.Rotate(mockRotatable.Object);

        Assert.AreEqual(345, mockRotatable.Object.Direction);
    }

    [Test]
    public void Rotate_WhenDirectionUnreadable_Throws()
    {
        var mockRotatable = new Mock<IRotatable>();
        mockRotatable.SetupGet(r => r.Direction).Throws<InvalidOperationException>();
        var rotator = new RotationMove();
        
        Assert.Throws<InvalidOperationException>(() => rotator.Rotate(mockRotatable.Object));
    }

    [Test]
    public void Rotate_WhenAngularVelocityUnreadable_Throws()
    {
        var mockRotatable = new Mock<IRotatable>();
        mockRotatable.SetupGet(r => r.AngularVelocity).Throws<InvalidOperationException>();
        var rotator = new RotationMove();
        
        Assert.Throws<InvalidOperationException>(() => rotator.Rotate(mockRotatable.Object));
    }

    [Test]
    public void Rotate_WhenDirectionNotSettable_Throws()
    {
        var mockRotatable = new Mock<IRotatable>();
        mockRotatable.SetupSet(r => r.Direction = It.IsAny<int>()).Throws<InvalidOperationException>();
        var rotator = new RotationMove();

        
        Assert.Throws<InvalidOperationException>(() => rotator.Rotate(mockRotatable.Object));
    }
}