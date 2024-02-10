using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ComputerCoolingBuilder
{
    public ComputerCoolingBuilder()
    {
        ComputerCooling = new ComputerCooling();
    }

    protected ComputerCooling ComputerCooling { get; private set; }

    public ComputerCoolingBuilder SetModel(string model)
    {
        ComputerCooling.Model = model;
        return this;
    }

    public ComputerCoolingBuilder SetSize(ushort lenght, ushort width, ushort height)
    {
        ComputerCooling.Lenght = lenght;
        ComputerCooling.Width = width;
        ComputerCooling.Height = height;

        return this;
    }

    public ComputerCoolingBuilder SetPowerDissipation(ushort powerDissipation)
    {
        ComputerCooling.PowerDissipation = powerDissipation;
        return this;
    }

    public ComputerCoolingBuilder SetSupportingSocket(Socket socket)
    {
        ComputerCooling.AddSockets(socket);
        return this;
    }

    public ComputerCooling Build()
    {
        if (ComputerCooling.Model is not null && ComputerCooling.Lenght != 0 && ComputerCooling.Height != 0 && ComputerCooling.Width != 0 && ComputerCooling.PowerDissipation != 0)
        {
            return ComputerCooling;
        }

        throw new MissingAttributeException("Attribute from ComputerCooling is missing");
    }
}