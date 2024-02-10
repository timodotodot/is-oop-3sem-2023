namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Jumping;

public class JumpingEngineAlpha : JumpingEngine
{
    public JumpingEngineAlpha()
    {
        RangeOfJump = 110;
    }

    public override int FuelConsumtion(int distanceTraveled) => distanceTraveled;
}