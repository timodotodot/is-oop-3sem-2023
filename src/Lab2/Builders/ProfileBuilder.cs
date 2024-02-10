using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ProfileBuilder
{
    public ProfileBuilder()
    {
        Profile = new Profiles();
    }

    protected Profiles Profile { get; private set; }

    public ProfileBuilder SetType(ProfileType type)
    {
        Profile.Type = type;
        return this;
    }

    public ProfileBuilder SetTiming(string timing)
    {
        Profile.Timing = timing;
        return this;
    }

    public ProfileBuilder SetVoltage(double voltage)
    {
        Profile.Voltage = voltage;
        return this;
    }

    public ProfileBuilder SetFrequency(ushort frequency)
    {
        Profile.Frequency = frequency;
        return this;
    }

    public Profiles Build()
    {
        if (Profile.Timing is not null && Profile.Voltage != 0 && Profile.Frequency != 0)
        {
            return Profile;
        }

        throw new MissingAttributeException("Attribute is missing");
    }
}