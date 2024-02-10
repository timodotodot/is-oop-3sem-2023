using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Computer
{
    private List<Ram> _rams = new List<Ram>();
    private List<StorageDevice> _storageDevices = new List<StorageDevice>();

    public string? Model { get; set; }
    public MotherBoard? MotherBoard { get; set; }
    public Cpu? Cpu { get; set; }
    public ComputerCooling? ComputerCooling { get; set; }
    public Profiles? Profile { get; set; }
    public Gpu? Gpu { get; set; }
    public PcCase? PcCase { get; set; }
    public PowerUnit? PowerUnit { get; set; }
    public double PowerConsumption { get; set; }

    public IReadOnlyList<Ram> Rams
    {
        get { return _rams.AsReadOnly(); }
    }

    public IReadOnlyList<StorageDevice> StorageDevices
    {
        get { return _storageDevices.AsReadOnly(); }
    }

    public void AddRam(Ram ram)
    {
        _rams.Add(ram);
    }

    public void AddStorageDeviec(StorageDevice storageDevice)
    {
        _storageDevices.Add(storageDevice);
    }
}