using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class PcCase
{
    private List<FormFactorMotherBoard> _supportingMotherBoard;

    public PcCase()
    {
        _supportingMotherBoard = new List<FormFactorMotherBoard>();
    }

    public ushort GpuMaxLength { get; set; }
    public ushort GpuMaxWidth { get; set; }

    public ushort Height { get; set; }
    public ushort Width { get; set; }
    public ushort Length { get; set; }

    public void AddSupportingMotherBoards(FormFactorMotherBoard formFactorMotherBoard)
    {
        _supportingMotherBoard.Add(formFactorMotherBoard);
    }

    public bool CheckingMotherBoardFormFactor(FormFactorMotherBoard formFactorMotherBoard)
    {
        return _supportingMotherBoard.Contains(formFactorMotherBoard);
    }
}