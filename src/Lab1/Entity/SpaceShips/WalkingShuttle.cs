using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.HullStrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.SpaceShips;

public class WalkingShuttle : SpaceShip
{
    public WalkingShuttle()
    {
        Name = "Простой корабль";
        ImpulseEngine = new ImpulseEngineClassC(20);
        JumpingEngine = null;
        Deflector = null;
        Hull = new HullStrengthClass1();
        IsThereAntiNitrineEmitter = false;
    }
}