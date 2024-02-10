using Itmo.ObjectOrientedProgramming.Lab1.Entity.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.HullStrengthClasses;

public class HullStrength
{
    public bool IsActive { get; protected set; }
    public int Armor { get; set; }
    protected double DamageCoefficient { get; set; }

    public void TakeDamage(Obstacle obstacle)
    {
        if (obstacle is Meteoroid || obstacle is SmallAsteroid || obstacle is SpaceWhale)
        {
            Armor -= (int)(obstacle.Damage * DamageCoefficient);
            CheckStatusArmor();
        }
        else
        {
            throw new InvalidTypeException("Invalid object type.");
        }
    }

    private void CheckStatusArmor()
    {
        if (Armor <= 0)
        {
            IsActive = false;
        }
    }
}