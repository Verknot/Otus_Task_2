using Otus_Task_2.Interface;

namespace Otus_Task_2.Move;

public class LinearMovement
{
    public void Move(IMovable movable)
    {
        if (movable == null)
            throw new ArgumentNullException(nameof(movable));

        try
        {
            var currentPosition = movable.Position;
            var velocity = movable.Velocity;
            movable.Position = currentPosition + velocity;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Movement failed.", ex);
        }
    }
}