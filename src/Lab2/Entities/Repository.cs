using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Repository : IRepository
{
    private static IRepository? _instance;

    private List<MotherBoardBuilder> _motherBoards;
    private List<CpuBuilder> _cpu;
    private List<ComputerCoolingBuilder> _computerCoolings;
    private List<RamBuilder> _ram;
    private List<GpuBuilder> _gpu;
    private List<StorageDeviceBuilder> _storageDevices;
    private List<PowerUnit> _powerUnits;
    private List<WiFiModuleBuilder> _wiFiModules;
    private List<BiosBuilder> _bios;
    private List<PcBuilder> _computers;
    private List<ProfileBuilder> _profile;

    private Repository()
    {
        _motherBoards = new List<MotherBoardBuilder>();
        _cpu = new List<CpuBuilder>();
        _computerCoolings = new List<ComputerCoolingBuilder>();
        _ram = new List<RamBuilder>();
        _gpu = new List<GpuBuilder>();
        _storageDevices = new List<StorageDeviceBuilder>();
        _powerUnits = new List<PowerUnit>();
        _wiFiModules = new List<WiFiModuleBuilder>();
        _bios = new List<BiosBuilder>();
        _computers = new List<PcBuilder>();
        _profile = new List<ProfileBuilder>();
    }

    public static IRepository Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new Repository();
            }

            return _instance;
        }
    }

    public void Add(object attribute)
    {
        switch (attribute)
        {
            case MotherBoardBuilder motherBoard:
                _motherBoards.Add(motherBoard);
                break;

            case CpuBuilder cpu:
                _cpu.Add(cpu);
                break;

            case ComputerCoolingBuilder computerCooling:
                _computerCoolings.Add(computerCooling);
                break;

            case RamBuilder ram:
                _ram.Add(ram);
                break;

            case GpuBuilder gpu:
                _gpu.Add(gpu);
                break;

            case StorageDeviceBuilder storageDevice:
                _storageDevices.Add(storageDevice);
                break;

            case PowerUnit powerUnit:
                _powerUnits.Add(powerUnit);
                break;

            case WiFiModuleBuilder wiFi:
                _wiFiModules.Add(wiFi);
                break;

            case BiosBuilder bios:
                _bios.Add(bios);
                break;

            case PcBuilder computer:
                _computers.Add(computer);
                break;

            case ProfileBuilder profile:
                _profile.Add(profile);
                break;

            default: throw new WrongTypeObjectException("Wrong object type");
        }
    }

    public MotherBoardBuilder GetMotherBoard(string model)
    {
        return _motherBoards.FirstOrDefault(board => board.Build().Model == model)
               ?? throw new ModelMissingException("MotherBoard is missing in repository");
    }

    public CpuBuilder GetCpu(string model)
    {
        return _cpu.FirstOrDefault(cpu => cpu.Build().Model == model)
               ?? throw new ModelMissingException("CPU is missing in repository");
    }

    public ComputerCoolingBuilder GetComputerCooling(string model)
    {
        return _computerCoolings.FirstOrDefault(computerCooling => computerCooling.Build().Model == model)
               ?? throw new ModelMissingException("ComputerCooling is missing in repository");
    }

    public RamBuilder GetRam(string model)
    {
        return _ram.FirstOrDefault(ram => ram.Build().Model == model)
               ?? throw new ModelMissingException("RAM is missing in repository");
    }

    public GpuBuilder GetGpu(string model)
    {
        return _gpu.FirstOrDefault(gpu => gpu.Build().Model == model)
               ?? throw new ModelMissingException("GPU is missing in repository");
    }

    public StorageDeviceBuilder GetStorageDevice(string model)
    {
        return _storageDevices.FirstOrDefault(ssd => ssd.Build().Model == model)
               ?? throw new ModelMissingException("SSD is missing in repository");
    }

    public PowerUnit GetPowerUnit(string model)
    {
        return _powerUnits.FirstOrDefault(powerUnit => powerUnit.Model == model)
               ?? throw new ModelMissingException("PowerUnit is missing in repository");
    }

    public WiFiModuleBuilder GetWiFiModule(string model)
    {
        return _wiFiModules.FirstOrDefault(wiFi => wiFi.Build().Version == model)
               ?? throw new ModelMissingException("Wi-Fi module is missing in repository");
    }

    public BiosBuilder GetBios(string model)
    {
        return _bios.FirstOrDefault(bios => bios.Build().Model == model)
               ?? throw new ModelMissingException("Bios is missing in repository");
    }

    public PcBuilder GetComputer(string model)
    {
        return _computers.FirstOrDefault(computer => computer.Build().Model == model)
               ?? throw new ModelMissingException("Computer is missing in repository");
    }

    public ProfileBuilder GetProfile(string model)
    {
        return _profile.FirstOrDefault(profile => profile.Build().Model == model)
               ?? throw new ModelMissingException("Profile is missing in repository");
    }
}