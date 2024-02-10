using Itmo.ObjectOrientedProgramming.Lab1.Models.Types;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Jumping;

public abstract class JumpingEngine
{
    public int RangeOfJump { get; protected set; }
    public TypeOfFuel Fuel { get; protected set; } = TypeOfFuel.GravitonMaterial;
    public abstract int FuelConsumtion(int distanceTraveled);
}