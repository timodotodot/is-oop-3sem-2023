using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public abstract class Deflector
{
    public int Armor { get; protected set; }
    public int ReflectionOfFlashes { get; protected set; }
    public double DamageCoefficient { get; protected set; }
    public bool IsActive { get; protected set; }
    public bool PhotonDeflectorIsActive { get; protected set; }

    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is Meteoroid || obstacle is SmallAsteroid || obstacle is SpaceWhale)
        {
            Armor -= (int)(obstacle.Damage * DamageCoefficient);
            CheckStatusArmor();
        }

        if (obstacle is AntimatterFlash)
        {
            ReflectionOfFlashes--;
            CheckStatusPhotonDeflector();
        }
    }

    private void CheckStatusArmor()
    {
        if (Armor <= 0)
        {
            IsActive = false;
            PhotonDeflectorIsActive = false;
        }
    }

    private void CheckStatusPhotonDeflector()
    {
        if (ReflectionOfFlashes <= 0)
        {
            PhotonDeflectorIsActive = false;
        }
    }
}