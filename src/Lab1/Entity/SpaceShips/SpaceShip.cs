using Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Jumping;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.HullStrengthClasses;
using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.SpaceShips;

public class SpaceShip
{
    public string? Name { get; protected set; }
    public ImpulseEngine? ImpulseEngine { get; protected set; }
    public JumpingEngine? JumpingEngine { get; protected set; }
    public Deflector? Deflector { get; protected set; }
    public HullStrength? Hull { get; protected set; }
    public bool IsThereAntiNitrineEmitter { get; protected set; }
    public bool IsAlive { get; protected set; } = true;

    public void TakeDamage(Obstacle obstacle)
    {
        if (!(IsThereAntiNitrineEmitter && obstacle is SpaceWhale))
        {
            switch (obstacle)
            {
                case Meteoroid:
                    if (Deflector is not null && Deflector.IsActive)
                    {
                        Deflector.TakeDamage(obstacle);
                    }
                    else if (Hull is not null && Hull.IsActive)
                    {
                        Hull.TakeDamage(obstacle);
                    }
                    else
                    {
                        IsAlive = false;
                    }

                    break;

                case SmallAsteroid:
                    if (Deflector is not null && Deflector.IsActive)
                    {
                        Deflector.TakeDamage(obstacle);
                    }
                    else if (Hull is not null && Hull.IsActive)
                    {
                        Hull.TakeDamage(obstacle);
                    }
                    else
                    {
                        IsAlive = false;
                    }

                    break;

                case AntimatterFlash:
                    if (Deflector is not null && Deflector.IsActive && Deflector.PhotonDeflectorIsActive)
                    {
                        Deflector.TakeDamage(obstacle);
                    }
                    else
                    {
                        IsAlive = false;
                    }

                    break;

                case SpaceWhale:
                    if (Deflector is not null && Deflector.IsActive && Deflector is DeflectorClass3)
                    {
                        Deflector.TakeDamage(obstacle);
                    }
                    else
                    {
                        IsAlive = false;
                    }

                    break;
                default:
                    throw new InvalidTypeException("Type is not defined");
            }
        }
    }
}