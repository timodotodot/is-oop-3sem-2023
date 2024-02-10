using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Types;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerCooling
{
    private List<Socket> _sockets;
    public ComputerCooling()
    {
        _sockets = new List<Socket>();
    }

    public string? Model { get; set; }
    public ushort Height { get; set; }
    public ushort Lenght { get; set; }
    public ushort Width { get; set; }
    public ushort PowerDissipation { get; set; }

    public void AddSockets(Socket socket)
    {
        _sockets.Add(socket);
    }

    public bool CheckingSocket(Socket socket)
    {
        return _sockets.Contains(socket);
    }
}