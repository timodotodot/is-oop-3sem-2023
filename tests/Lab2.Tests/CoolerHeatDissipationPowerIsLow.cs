using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Types;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class CoolerHeatDissipationPowerIsLow
{
    [Fact]
    public void CoolerHeatDissipationPowerIsLowTest()
    {
        // Arrange
        IRepository repository = Repository.Instance;

        var builderBios = new BiosBuilder();
        Bios bios = builderBios
            .SetType(BiosType.Uefi)
            .SetVersion("2.0")
            .SetSupportingCpu("i9-9900K")
            .Build();

        var builderMotherBoard = new MotherBoardBuilder();
        MotherBoard motherBoard = builderMotherBoard
            .SetModel("MSI MAG Z590 TORPEDO")
            .SetSocket(Socket.Lga1200)
            .SetPciExpressLines(1)
            .SetSataPorts(6)
            .SetChipset(Chipset.Z690)
            .SetBios(bios)
            .SetDdr(Ddr.Four)
            .SetRamSlots(4)
            .SetFormFactor(FormFactorMotherBoard.StandardAtx)
            .Build();
        repository.Add(builderMotherBoard);

        var builderCpu = new CpuBuilder();
        Cpu cpu = builderCpu
            .SetModel("i9-11900K")
            .SetSocket(Socket.Lga1200)
            .SetFrequency(3.5)
            .SetCoreCount(8)
            .SetMemoryFrequency(3200)
            .SetTdp(125)
            .Build();
        repository.Add(builderCpu);

        var builderCooling = new ComputerCoolingBuilder();
        ComputerCooling cooling = builderCooling
            .SetModel("DEEPCOOL AK620")
            .SetSize(138, 129, 160)
            .SetSupportingSocket(Socket.Am4)
            .SetSupportingSocket(Socket.Am5)
            .SetSupportingSocket(Socket.Lga1200)
            .SetSupportingSocket(Socket.Lga1700)
            .SetPowerDissipation(100)
            .Build();
        repository.Add(builderCooling);

        var builderIntelXmp = new ProfileBuilder();
        Profiles xmp = builderIntelXmp
            .SetType(ProfileType.Xmp)
            .SetTiming("16-20-20")
            .SetFrequency(3200)
            .SetVoltage(1.35)
            .Build();

        var builderRam = new RamBuilder();
        Ram ram = builderRam
            .SetModel("Kingston FURY Beast Black")
            .SetMemory(32)
            .SetFrequency(3200)
            .SetDdr(Ddr.Four)
            .SetVoltage(1.35)
            .SetFormFactor(RamFormFactor.Dimm)
            .SetProfile(xmp)
            .Build();
        repository.Add(builderRam);

        var builderGpu = new GpuBuilder();
        Gpu gpu = builderGpu
            .SetModel("RTX 4070 Ti")
            .SetVideoMemory(12)
            .SetPciExpressVersion("PCI-E 4.0")
            .SetFrequency(2310.0)
            .SetSize(329, 128)
            .SetVoltage(285)
            .Build();
        repository.Add(builderGpu);

        var builderHdd = new StorageDeviceBuilder();
        StorageDevice hdd = builderHdd
            .SetModel("HDD 2TB")
            .SetType(TypeStorageDevice.Hdd)
            .SetMemory(2048)
            .SetSpeedWork(7200)
            .SetVoltage(6.8)
            .Build();
        repository.Add(builderHdd);

        var builderPcCase = new PcCaseBuilder();
        PcCase pcCase = builderPcCase
            .SetSize(386, 230, 491)
            .SetGpuMaxSize(330, 220)
            .SetSupportingMotherBoardFormFactor(FormFactorMotherBoard.StandardAtx)
            .SetSupportingMotherBoardFormFactor(FormFactorMotherBoard.MicroAtx)
            .Build();

        var powerUnit = new PowerUnit("beQuiet 400W", 800);

        // Act
        var builderComputer = new PcBuilder();
        Computer computer = builderComputer
            .SetName("TERMINATOR2208")
            .SetPcCase(pcCase)
            .SetMotherBoard(motherBoard)
            .SetCpu(cpu)
            .SetRam(ram)
            .SetComputerCooling(cooling)
            .SetPowerUnit(powerUnit)
            .SetStorageDevice(hdd)
            .SetGpu(gpu)
            .Build();
        repository.Add(builderComputer);

        var computerAssemblyCheck = new ComputerAssemblyCheck();
        computerAssemblyCheck.GetCheckList(computer);

        const string comment = "The heat dissipation of the cooler is less than the TDP of the CPU";
        string expectedResult = comment;
        string result = " ";

        if (computerAssemblyCheck.CheckError(comment))
        {
            result = comment;
        }

        // Assert
        Assert.Equal(expectedResult, result);
    }
}