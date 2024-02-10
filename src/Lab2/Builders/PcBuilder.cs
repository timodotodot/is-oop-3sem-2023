using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class PcBuilder
{
    public PcBuilder()
    {
        Computer = new Computer();
    }

    protected Computer Computer { get; private set; }

    public PcBuilder SetMotherBoard(MotherBoard motherBoard)
    {
        if (Computer.PcCase is null)
        {
            throw new AssemblyOrderBrokenException("For Motherboard you need a PcCase");
        }

        if (motherBoard is null)
        {
            throw new ObjectNullException("MotherBoard is null");
        }

        Computer.MotherBoard = motherBoard;
        return this;
    }

    public PcBuilder SetCpu(Cpu cpu)
    {
        if (Computer.MotherBoard is null)
        {
            throw new AssemblyOrderBrokenException("For CPU you need a Motherboard");
        }

        if (cpu is null)
        {
            throw new ObjectNullException("CPU is null");
        }

        Computer.Cpu = cpu;
        Computer.PowerConsumption += cpu.Tdp;

        return this;
    }

    public PcBuilder SetRam(Ram ram)
    {
        if (Computer.Cpu is null)
        {
            throw new AssemblyOrderBrokenException("Before RAM you need to install a CPU");
        }

        if (ram is null)
        {
            throw new ObjectNullException("RAM is null");
        }

        Computer.AddRam(ram);
        Computer.PowerConsumption += ram.Voltage;
        return this;
    }

    public PcBuilder SetComputerCooling(ComputerCooling computerCooling)
    {
        if (computerCooling is null)
        {
            throw new ObjectNullException("ComputerCooling is null");
        }

        if (Computer.Rams.Count == 0)
        {
            throw new AssemblyOrderBrokenException("Before ComputerCooling you need to install a RAM");
        }

        Computer.ComputerCooling = computerCooling;
        return this;
    }

    public PcBuilder SetPcCase(PcCase pcCase)
    {
        if (pcCase is null)
        {
            throw new ObjectNullException("PcCase is null");
        }

        Computer.PcCase = pcCase;
        return this;
    }

    public PcBuilder SetPowerUnit(PowerUnit powerUnit)
    {
        if (Computer.PcCase is null)
        {
            throw new AssemblyOrderBrokenException("For PowerUnit you need a PcCase");
        }

        if (powerUnit is null)
        {
            throw new ObjectNullException("PowerUnit is null");
        }

        Computer.PowerUnit = powerUnit;
        return this;
    }

    public PcBuilder SetStorageDevice(StorageDevice storageDevice)
    {
        if (Computer.PowerUnit is null)
        {
            throw new AssemblyOrderBrokenException("Before StorageDevice you need to install a PowerUnit");
        }

        if (storageDevice is null)
        {
            throw new ObjectNullException("StorageDevice is null");
        }

        Computer.AddStorageDeviec(storageDevice);
        Computer.PowerConsumption += storageDevice.Voltage;
        return this;
    }

    public PcBuilder SetGpu(Gpu gpu)
    {
        if (gpu is null)
        {
            throw new ObjectNullException("GPU is null");
        }

        Computer.Gpu = gpu;
        Computer.PowerConsumption += gpu.Voltage;
        return this;
    }

    public PcBuilder SetName(string name)
    {
        Computer.Model = name;
        return this;
    }

    public Computer Build()
    {
        if (Computer.Cpu is not null && Computer.Model is not null && Computer.MotherBoard is not null && Computer.ComputerCooling is not null &&
            Computer.PowerUnit is not null)
        {
            return Computer;
        }

        throw new MissingAttributeException("Attribute from Computer is missing");
    }
}