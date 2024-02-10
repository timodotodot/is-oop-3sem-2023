using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class StorageDevice
{
    public string? Model { get; set; }
    public TypeStorageDevice Type { get; set; }
    public ushort Memory { get; set; }
    public ushort SpeedWork { get; set; }
    public double Voltage { get; set; }
}