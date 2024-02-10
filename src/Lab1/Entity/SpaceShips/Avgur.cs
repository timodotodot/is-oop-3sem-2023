using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Jumping;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.HullStrengthClasses;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.SpaceShips;

public class Avgur : SpaceShip
{
    public Avgur(bool isTherePhotonDeflector)
    {
        Name = "Боевой корабль";
        ImpulseEngine = new ImpulseEngineClassE(30);
        JumpingEngine = new JumpingEngineAlpha();
        Deflector = new DeflectorClass3(isTherePhotonDeflector);
        Hull = new HullStrengthClass3();
        IsThereAntiNitrineEmitter = false;
    }
}