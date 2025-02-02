using Otus_Task_2.Interface;

namespace Otus_Task_2.Move;

public class RotationMove
{
    public void Rotate(IRotatable rotatable)
    {
        if (rotatable == null)
            throw new ArgumentNullException(nameof(rotatable));

        try
        {
            int newDirection = (rotatable.Direction + rotatable.AngularVelocity) % 360;
            if (newDirection < 0) newDirection += 360;
            rotatable.Direction = newDirection;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Rotation failed.", ex);
        }
    }
}