using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class PcCaseBuilder
{
    public PcCaseBuilder()
    {
        PcCase = new PcCase();
    }

    protected PcCase PcCase { get; private set; }

    public PcCaseBuilder SetGpuMaxSize(ushort maxLength, ushort maxWidth)
    {
        PcCase.GpuMaxLength = maxLength;
        PcCase.GpuMaxWidth = maxWidth;

        return this;
    }

    public PcCaseBuilder SetSize(ushort length, ushort width, ushort height)
    {
        PcCase.Length = length;
        PcCase.Width = width;
        PcCase.Height = height;

        return this;
    }

    public PcCaseBuilder SetSupportingMotherBoardFormFactor(FormFactorMotherBoard formFactorMotherBoard)
    {
        PcCase.AddSupportingMotherBoards(formFactorMotherBoard);
        return this;
    }

    public PcCase Build()
    {
        if (PcCase.GpuMaxLength + PcCase.GpuMaxWidth + PcCase.Length + PcCase.Width + PcCase.Height != 0)
        {
            return PcCase;
        }

        throw new MissingAttributeException("Attribute from PcCase is missing");
    }
}