using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Engines.Jumping;

public class JumpingEngineOmega : JumpingEngine
{
    public JumpingEngineOmega()
    {
        RangeOfJump = 250;
    }

    public override int FuelConsumtion(int distanceTraveled) => distanceTraveled * (int)Math.Log2(distanceTraveled);
}