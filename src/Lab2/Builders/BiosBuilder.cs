using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class BiosBuilder
{
    public BiosBuilder()
    {
        Bios = new Bios();
    }

    protected Bios Bios { get; private set; }

    public BiosBuilder SetModel(string model)
    {
        Bios.Model = model;
        return this;
    }

    public BiosBuilder SetType(BiosType type)
    {
        Bios.Type = type;
        return this;
    }

    public BiosBuilder SetVersion(string version)
    {
        Bios.Version = version;
        return this;
    }

    public BiosBuilder SetSupportingCpu(string cpu)
    {
        Bios.AddSupportingCpu(cpu);
        return this;
    }

    public Bios Build()
    {
        return Bios;
    }
}