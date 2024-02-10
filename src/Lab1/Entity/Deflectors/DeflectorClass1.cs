namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public class DeflectorClass1 : Deflector
{
    public DeflectorClass1(bool isTherePhotonDeflector)
    {
        Armor = 50;
        IsActive = true;
        DamageCoefficient = 1.0;

        if (isTherePhotonDeflector)
        {
            PhotonDeflectorIsActive = true;
            ReflectionOfFlashes = 3;
        }
    }
}