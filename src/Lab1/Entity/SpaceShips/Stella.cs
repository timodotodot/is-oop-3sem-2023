using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Jumping;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.HullStrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.SpaceShips;

public class Stella : SpaceShip
{
    public Stella(bool isTherePhotonDeflector)
    {
        Name = "Дипломатический корабль";
        ImpulseEngine = new ImpulseEngineClassC(50);
        JumpingEngine = new JumpingEngineOmega();
        Deflector = new DeflectorClass1(isTherePhotonDeflector);
        Hull = new HullStrengthClass1();
        IsThereAntiNitrineEmitter = false;
    }
}