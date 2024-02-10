using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class StorageDeviceBuilder
{
    public StorageDeviceBuilder()
    {
        StorageDevice = new StorageDevice();
    }

    protected StorageDevice StorageDevice { get; private set; }

    public StorageDeviceBuilder SetModel(string model)
    {
        StorageDevice.Model = model;
        return this;
    }

    public StorageDeviceBuilder SetType(TypeStorageDevice type)
    {
        StorageDevice.Type = type;
        return this;
    }

    public StorageDeviceBuilder SetMemory(ushort memory)
    {
        StorageDevice.Memory = memory;
        return this;
    }

    public StorageDeviceBuilder SetSpeedWork(ushort speedWork)
    {
        StorageDevice.SpeedWork = speedWork;
        return this;
    }

    public StorageDeviceBuilder SetVoltage(double voltage)
    {
        StorageDevice.Voltage = voltage;
        return this;
    }

    public StorageDevice Build()
    {
        if (StorageDevice.Model is not null && StorageDevice.Memory != 0 && StorageDevice.SpeedWork != 0 && StorageDevice.Voltage != 0)
        {
            return StorageDevice;
        }

        throw new MissingAttributeException("Attribute from StorageDevice is missing");
    }
}