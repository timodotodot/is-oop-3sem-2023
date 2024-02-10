using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ShipWasDestroyedException : Exception
{
    public ShipWasDestroyedException() { }

    public ShipWasDestroyedException(string message)
        : base(message) { }

    public ShipWasDestroyedException(string message, Exception innerException)
        : base(message, innerException) { }
}