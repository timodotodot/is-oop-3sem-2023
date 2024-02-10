using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Profiles
{
    public ProfileType Type { get; set; }
    public string? Model { get; set; }
    public string? Timing { get; set; }
    public double Voltage { get; set; }
    public ushort Frequency { get; set; }
}