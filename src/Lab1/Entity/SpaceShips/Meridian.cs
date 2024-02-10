using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.HullStrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.SpaceShips;

public class Meridian : SpaceShip
{
    public Meridian(bool isTherePhotonDeflector)
    {
        Name = "Добывающий корабль";
        ImpulseEngine = new ImpulseEngineClassE(35);
        JumpingEngine = null;
        Deflector = new DeflectorClass2(isTherePhotonDeflector);
        Hull = new HullStrengthClass2();
        IsThereAntiNitrineEmitter = true;
    }
}