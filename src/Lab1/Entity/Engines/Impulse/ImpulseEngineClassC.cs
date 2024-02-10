using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;

public class ImpulseEngineClassC : ImpulseEngine
{
    public ImpulseEngineClassC(int speed)
    {
        Speed = speed;
    }

    public override void SpeedUp(int boost)
    {
        throw new EngineCantSpeedUpException("Class C cant speed up");
    }

    public override int FuelConsumtion() => Speed / 4;
}