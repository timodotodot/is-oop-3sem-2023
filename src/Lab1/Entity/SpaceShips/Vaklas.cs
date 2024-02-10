using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Jumping;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.HullStrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.SpaceShips;

public class Vaklas : SpaceShip
{
    public Vaklas(bool isTherePhotonDeflector)
    {
        Name = "Исследовательский корабль";
        ImpulseEngine = new ImpulseEngineClassE(35);
        JumpingEngine = new JumpingEngineGamma();
        Deflector = new DeflectorClass1(isTherePhotonDeflector);
        Hull = new HullStrengthClass2();
        IsThereAntiNitrineEmitter = false;
    }
}