using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Bios
{
    private List<string> _cpuSupporting;

    public Bios()
    {
        _cpuSupporting = new List<string>();
    }

    public string? Model { get; set; }
    public BiosType Type { get; set; }
    public string? Version { get; set; }

    public void AddSupportingCpu(string cpu)
    {
        _cpuSupporting.Add(cpu);
    }

    public bool CheckingCpu(string cpu)
    {
        return _cpuSupporting.Contains(cpu);
    }
}