using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class RamBuilder
{
    public RamBuilder()
    {
        Ram = new Ram();
    }

    protected Ram Ram { get; private set; }

    public RamBuilder SetModel(string model)
    {
        Ram.Model = model;
        return this;
    }

    public RamBuilder SetMemory(byte memory)
    {
        Ram.Memory = memory;
        return this;
    }

    public RamBuilder SetFrequency(ushort frequency)
    {
        Ram.Frequency = frequency;
        return this;
    }

    public RamBuilder SetProfile(Profiles profiles)
    {
        Ram.Profile = profiles;
        return this;
    }

    public RamBuilder SetFormFactor(RamFormFactor formFactor)
    {
        Ram.FormFactor = formFactor;
        return this;
    }

    public RamBuilder SetDdr(Ddr ddr)
    {
        Ram.Ddr = ddr;
        return this;
    }

    public RamBuilder SetVoltage(double voltage)
    {
        Ram.Voltage = voltage;
        return this;
    }

    public Ram Build()
    {
        if (Ram.Model is not null && Ram.Memory != 0 && Ram.Frequency != 0 && Ram.Voltage != 0)
        {
            return Ram;
        }

        throw new MissingAttributeException("Attribute from RAM is missing");
    }
}