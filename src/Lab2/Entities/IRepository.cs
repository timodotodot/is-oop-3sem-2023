using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IRepository
{
    public void Add(object attribute);

    public MotherBoardBuilder GetMotherBoard(string model);
    public CpuBuilder GetCpu(string model);
    public ComputerCoolingBuilder GetComputerCooling(string model);
    public RamBuilder GetRam(string model);
    public GpuBuilder GetGpu(string model);
    public StorageDeviceBuilder GetStorageDevice(string model);
    public PowerUnit GetPowerUnit(string model);
    public WiFiModuleBuilder GetWiFiModule(string model);
    public BiosBuilder GetBios(string model);
    public PcBuilder GetComputer(string model);
    public ProfileBuilder GetProfile(string model);
}