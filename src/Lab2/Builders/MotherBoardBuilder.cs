using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class MotherBoardBuilder
{
    public MotherBoardBuilder()
    {
        MotherBoard = new MotherBoard();
    }

    protected MotherBoard MotherBoard { get; private set; }

    public MotherBoardBuilder SetModel(string model)
    {
        MotherBoard.Model = model;
        return this;
    }

    public MotherBoardBuilder SetSocket(Socket socket)
    {
        MotherBoard.Socket = socket;
        return this;
    }

    public MotherBoardBuilder SetPciExpressLines(byte pciExpressLines)
    {
        MotherBoard.PciExpressLines = pciExpressLines;
        return this;
    }

    public MotherBoardBuilder SetSataPorts(byte sataPorts)
    {
        MotherBoard.SataPorts = sataPorts;
        return this;
    }

    public MotherBoardBuilder SetDdr(Ddr ddr)
    {
        MotherBoard.Ddr = ddr;
        return this;
    }

    public MotherBoardBuilder SetChipset(Chipset chipset)
    {
        MotherBoard.Chipset = chipset;
        return this;
    }

    public MotherBoardBuilder SetRamSlots(byte ramSlots)
    {
        MotherBoard.CountSlotsRam = ramSlots;
        return this;
    }

    public MotherBoardBuilder SetFormFactor(FormFactorMotherBoard formFactor)
    {
        MotherBoard.FormFactorMotherBoard = formFactor;
        return this;
    }

    public MotherBoardBuilder SetBios(Bios bios)
    {
        MotherBoard.Bios = bios;
        return this;
    }

    public MotherBoard Build()
    {
        if (MotherBoard.Model is not null && MotherBoard.PciExpressLines != 0
                                          && MotherBoard.SataPorts != 0 && MotherBoard.CountSlotsRam != 0)
        {
            return MotherBoard;
        }

        throw new MissingAttributeException("Attribute from MotherBoard is missing");
    }
}