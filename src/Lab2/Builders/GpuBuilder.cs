using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class GpuBuilder
{
    public GpuBuilder()
    {
        Gpu = new Gpu();
    }

    protected Gpu Gpu { get; private set; }

    public GpuBuilder SetModel(string model)
    {
        Gpu.Model = model;
        return this;
    }

    public GpuBuilder SetSize(ushort length, ushort width)
    {
        Gpu.Length = length;
        Gpu.Width = width;

        return this;
    }

    public GpuBuilder SetVideoMemory(byte videoMemory)
    {
        Gpu.VideoMemory = videoMemory;
        return this;
    }

    public GpuBuilder SetPciExpressVersion(string version)
    {
        Gpu.PciExpressVersion = version;
        return this;
    }

    public GpuBuilder SetFrequency(double frequency)
    {
        Gpu.Frequency = frequency;
        return this;
    }

    public GpuBuilder SetVoltage(double voltage)
    {
        Gpu.Voltage = voltage;
        return this;
    }

    public Gpu Build()
    {
        if (Gpu.Model is not null && Gpu.Length != 0 && Gpu.Width != 0 && Gpu.VideoMemory != 0
            && Gpu.Frequency != 0 && Gpu.PciExpressVersion is not null && Gpu.Voltage != 0)
        {
            return Gpu;
        }

        throw new MissingAttributeException("Attribute from GPU is missing");
    }
}