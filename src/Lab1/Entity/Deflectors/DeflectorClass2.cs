namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public class DeflectorClass2 : Deflector
{
    public DeflectorClass2(bool isTherePhotonDeflector)
    {
        Armor = 90;
        IsActive = true;
        DamageCoefficient = 0.5;

        if (isTherePhotonDeflector)
        {
            PhotonDeflectorIsActive = true;
            ReflectionOfFlashes = 3;
        }
    }
}