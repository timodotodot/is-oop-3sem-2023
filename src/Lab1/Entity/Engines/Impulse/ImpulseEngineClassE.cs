namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;

public class ImpulseEngineClassE : ImpulseEngine
{
    public ImpulseEngineClassE(int speed)
    {
        Speed = speed;
    }

    public override void SpeedUp(int boost)
    {
        Speed += boost;
    }

    public override int FuelConsumtion() => Speed / 2;
}