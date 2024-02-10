namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class PowerUnit
{
    public PowerUnit(string model, ushort voltage)
    {
        Model = model;
        Voltage = voltage;
    }

    public string Model { get; private set; }
    public ushort Voltage { get; private set; }
}