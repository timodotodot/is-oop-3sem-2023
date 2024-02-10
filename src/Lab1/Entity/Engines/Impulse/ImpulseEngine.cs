using Itmo.ObjectOrientedProgramming.Lab1.Models.Types;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;

public abstract class ImpulseEngine
{
    public int Speed { get; protected set; }
    public TypeOfFuel Fuel { get; protected set; } = TypeOfFuel.ActivePlasma;
    public abstract int FuelConsumtion();
    public abstract void SpeedUp(int boost);
}