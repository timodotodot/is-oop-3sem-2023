using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Ram
{
    public string? Model { get; set; }
    public byte Memory { get; set; }
    public ushort Frequency { get; set; }
    public Profiles? Profile { get; set; }
    public RamFormFactor FormFactor { get; set; }
    public Ddr Ddr { get; set; }
    public double Voltage { get; set; }
}