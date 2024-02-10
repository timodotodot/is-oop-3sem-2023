using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerAssemblyCheck
{
    private List<string> _checkList;

    public ComputerAssemblyCheck()
    {
        _checkList = new List<string>();
    }

    public AssemblyResult Result { get; private set; }

    public void GetCheckList(Computer computer)
    {
        if (computer is null)
        {
            throw new ObjectNullException("Computer is null");
        }

        if (computer.MotherBoard?.Socket != computer.Cpu?.Socket)
        {
            _checkList.Add("Motherboard and CPU socket mismatch");
            Result = AssemblyResult.DisclaimerWarranty;
        }

        foreach (Ram ram in computer.Rams)
        {
            if (computer.MotherBoard?.Ddr != ram.Ddr)
            {
                _checkList.Add("Different DDRs for motherboard and RAM");

                if (Result != AssemblyResult.DisclaimerWarranty)
                {
                    Result = AssemblyResult.AnyComments;
                }

                break;
            }

            if (computer.Cpu?.MemoryFrequency < ram.Frequency)
            {
                _checkList.Add("The processor's memory frequency is less than the RAM frequency");

                if (Result != AssemblyResult.DisclaimerWarranty)
                {
                    Result = AssemblyResult.AnyComments;
                }

                break;
            }
        }

        if (computer.StorageDevices.Count == 0)
        {
            _checkList.Add("No storageDevice");

            if (Result != AssemblyResult.DisclaimerWarranty)
            {
                Result = AssemblyResult.AnyComments;
            }
        }

        if (computer.MotherBoard?.Bios is null)
        {
            _checkList.Add("No BIOS");

            if (Result != AssemblyResult.DisclaimerWarranty)
            {
                Result = AssemblyResult.AnyComments;
            }
        }

        if (computer.ComputerCooling?.PowerDissipation <= computer.Cpu?.Tdp)
        {
            _checkList.Add("The heat dissipation of the cooler is less than the TDP of the CPU");
            Result = AssemblyResult.DisclaimerWarranty;
        }

        if (computer.Cpu?.GraphicCore is null && computer.Gpu is null)
        {
            _checkList.Add("CPU don't have GraphicCore. You need a GPU");

            if (Result != AssemblyResult.DisclaimerWarranty)
            {
                Result = AssemblyResult.AnyComments;
            }
        }

        if (computer.Gpu is not null && (computer.PcCase?.GpuMaxLength < computer.Gpu.Length ||
                                         computer.PcCase?.GpuMaxWidth < computer.Gpu.Width))
        {
            _checkList.Add("Size GPU larger than size PcCase for GPU");

            if (Result != AssemblyResult.DisclaimerWarranty)
            {
                Result = AssemblyResult.AnyComments;
            }
        }

        if (computer.PowerConsumption > computer.PowerUnit?.Voltage)
        {
            _checkList.Add("The power PowerUnit is lower than the power consumption of the computer");
            Result = AssemblyResult.DisclaimerWarranty;
        }

        if (computer.MotherBoard is not null && computer.MotherBoard.Bios is not null
                                             && computer.Cpu is not null && computer.Cpu.Model is not null)
        {
            if (!computer.MotherBoard.Bios.CheckingCpu(computer.Cpu.Model))
            {
                _checkList.Add("BIOS not supporting this CPU");

                if (Result != AssemblyResult.DisclaimerWarranty)
                {
                    Result = AssemblyResult.AnyComments;
                }
            }
        }

        if (computer.ComputerCooling is not null && computer.Cpu is not null)
        {
            if (!computer.ComputerCooling.CheckingSocket(computer.Cpu.Socket))
            {
                _checkList.Add("ComputerCooling not supporting this CPU socket");

                if (Result != AssemblyResult.DisclaimerWarranty)
                {
                    Result = AssemblyResult.AnyComments;
                }
            }
        }

        if (computer.PcCase is not null && computer.MotherBoard is not null)
        {
            if (!computer.PcCase.CheckingMotherBoardFormFactor(computer.MotherBoard.FormFactorMotherBoard))
            {
                _checkList.Add("PcCase not supporting this form factor of MotherBoard");

                if (Result != AssemblyResult.DisclaimerWarranty)
                {
                    Result = AssemblyResult.AnyComments;
                }
            }
        }

        if (_checkList.Count == 0)
        {
            Result = AssemblyResult.Success;
        }
    }

    public bool CheckError(string error)
    {
        return _checkList.Contains(error);
    }
}