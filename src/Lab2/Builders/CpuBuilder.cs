using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CpuBuilder
{
    public CpuBuilder()
    {
        Cpu = new Cpu();
    }

    protected Cpu Cpu { get; private set; }

    public CpuBuilder SetModel(string model)
    {
        Cpu.Model = model;
        return this;
    }

    public CpuBuilder SetFrequency(double frequency)
    {
        Cpu.Frequency = frequency;
        return this;
    }

    public CpuBuilder SetCoreCount(byte coreCount)
    {
        Cpu.CoreCount = coreCount;
        return this;
    }

    public CpuBuilder SetSocket(Socket socket)
    {
        Cpu.Socket = socket;
        return this;
    }

    public CpuBuilder SetMemoryFrequency(ushort memoryFrequency)
    {
        Cpu.MemoryFrequency = memoryFrequency;
        return this;
    }

    public CpuBuilder SetGraphicCore(string graphicCore)
    {
        Cpu.GraphicCore = graphicCore;
        return this;
    }

    public CpuBuilder SetTdp(byte tdp)
    {
        Cpu.Tdp = tdp;
        return this;
    }

    public Cpu Build()
    {
        if (Cpu.Model is not null && Cpu.Frequency != 0 && Cpu.CoreCount != 0 && Cpu.MemoryFrequency != 0 && Cpu.Tdp != 0)
        {
            return Cpu;
        }

        throw new MissingAttributeException("Attribute from CPU is missing");
    }
}