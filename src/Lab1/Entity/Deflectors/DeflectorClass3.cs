namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Deflectors;

public class DeflectorClass3 : Deflector
{
    public DeflectorClass3(bool isTherePhotonDeflector)
    {
        Armor = 320;
        IsActive = true;
        DamageCoefficient = 0.45;

        if (isTherePhotonDeflector)
        {
            PhotonDeflectorIsActive = true;
            ReflectionOfFlashes = 3;
        }
    }
}