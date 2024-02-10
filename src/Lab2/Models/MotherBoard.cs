using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class MotherBoard
{
    public string? Model { get; set; }
    public Socket Socket { get; set; }
    public byte PciExpressLines { get; set; }
    public byte SataPorts { get; set; }
    public Ddr Ddr { get; set; }
    public Chipset Chipset { get; set; }
    public byte CountSlotsRam { get; set; }
    public FormFactorMotherBoard FormFactorMotherBoard { get; set; }
    public Bios? Bios { get; set; }
}