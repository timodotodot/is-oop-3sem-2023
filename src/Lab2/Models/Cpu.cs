using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Cpu
{
    public string? Model { get; set; }
    public double Frequency { get; set; }
    public byte CoreCount { get; set; }
    public Socket Socket { get; set; }
    public ushort MemoryFrequency { get; set; }
    public string? GraphicCore { get; set; }
    public byte Tdp { get; set; }
}