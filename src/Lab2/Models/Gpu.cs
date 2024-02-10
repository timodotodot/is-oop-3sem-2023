namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Gpu
{
    public string? Model { get; set; }
    public ushort Length { get; set; }
    public ushort Width { get; set; }
    public byte VideoMemory { get; set; }
    public string? PciExpressVersion { get; set; }
    public double Frequency { get; set; }
    public double Voltage { get; set; }
}