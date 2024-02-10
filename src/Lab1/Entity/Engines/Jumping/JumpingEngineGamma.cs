namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Jumping;

public class JumpingEngineGamma : JumpingEngine
{
    public JumpingEngineGamma()
    {
        RangeOfJump = 500;
    }

    public override int FuelConsumtion(int distanceTraveled) => distanceTraveled * distanceTraveled;
}