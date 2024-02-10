using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Types;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class AssemblingComputerCompatibleComponents
{
    [Fact]
    public void AssemblingComputerCompatibleComponentsTest()
    {
        // Arrange
        IRepository repository = Repository.Instance;

        var builderGigabyteBios = new BiosBuilder();
        Bios gigabyteBios = builderGigabyteBios
            .SetType(BiosType.Uefi)
            .SetVersion("2.0")
            .SetSupportingCpu("AMD Ryzen 5 5600X")
            .Build();

        var builderGigabyteB550AorusEliteV2 = new MotherBoardBuilder();
        MotherBoard gigabyteB550AorusEliteV2 = builderGigabyteB550AorusEliteV2
            .SetModel("GIGABYTE B550 AORUS ELITE V2")
            .SetSocket(Socket.Am4)
            .SetPciExpressLines(1)
            .SetSataPorts(4)
            .SetChipset(Chipset.B550)
            .SetBios(gigabyteBios)
            .SetDdr(Ddr.Four)
            .SetRamSlots(4)
            .SetFormFactor(FormFactorMotherBoard.StandardAtx)
            .Build();
        repository.Add(builderGigabyteB550AorusEliteV2);

        var builderAmdRyzen55600X = new CpuBuilder();
        Cpu amdRyzen55600X = builderAmdRyzen55600X
            .SetModel("AMD Ryzen 5 5600X")
            .SetSocket(Socket.Am4)
            .SetFrequency(3.7)
            .SetCoreCount(6)
            .SetMemoryFrequency(3200)
            .SetTdp(65)
            .Build();
        repository.Add(builderAmdRyzen55600X);

        var builderDeepcoolAk620 = new ComputerCoolingBuilder();
        ComputerCooling deepcoolAk620 = builderDeepcoolAk620
            .SetModel("DEEPCOOL AK620")
            .SetSize(138, 129, 160)
            .SetSupportingSocket(Socket.Am4)
            .SetSupportingSocket(Socket.Am5)
            .SetSupportingSocket(Socket.Lga1200)
            .SetSupportingSocket(Socket.Lga1700)
            .SetPowerDissipation(260)
            .Build();
        repository.Add(builderDeepcoolAk620);

        var builderIntelXmp = new ProfileBuilder();
        Profiles xmp = builderIntelXmp
            .SetType(ProfileType.Xmp)
            .SetTiming("16-20-20")
            .SetFrequency(3200)
            .SetVoltage(1.35)
            .Build();

        var builderKingstonFuryBeastBlack = new RamBuilder();
        Ram kingstonFuryBeastBlack = builderKingstonFuryBeastBlack
            .SetModel("Kingston FURY Beast Black")
            .SetMemory(16)
            .SetFrequency(3200)
            .SetDdr(Ddr.Four)
            .SetVoltage(1.35)
            .SetFormFactor(RamFormFactor.Dimm)
            .SetProfile(xmp)
            .Build();
        repository.Add(builderKingstonFuryBeastBlack);

        var builderRtx4070Ti = new GpuBuilder();
        Gpu rtx4070Ti = builderRtx4070Ti
            .SetModel("RTX 4070 Ti")
            .SetVideoMemory(12)
            .SetPciExpressVersion("PCI-E 4.0")
            .SetFrequency(2310.0)
            .SetSize(329, 128)
            .SetVoltage(285)
            .Build();
        repository.Add(builderRtx4070Ti);

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

        var powerUnit = new PowerUnit("KSAS 800W", 800);

        // Act
        var builderComputer = new PcBuilder();
        Computer computer = builderComputer
            .SetName("Top pc 2023")
            .SetPcCase(pcCase)
            .SetMotherBoard(gigabyteB550AorusEliteV2)
            .SetCpu(amdRyzen55600X)
            .SetRam(kingstonFuryBeastBlack)
            .SetRam(kingstonFuryBeastBlack)
            .SetComputerCooling(deepcoolAk620)
            .SetPowerUnit(powerUnit)
            .SetStorageDevice(hdd)
            .SetGpu(rtx4070Ti)
            .Build();
        repository.Add(builderComputer);

        var computerAssemblyCheck = new ComputerAssemblyCheck();
        computerAssemblyCheck.GetCheckList(computer);

        AssemblyResult expectedResult = AssemblyResult.Success;

        // Assert
        Assert.Equal(expectedResult, computerAssemblyCheck.Result);
    }
}