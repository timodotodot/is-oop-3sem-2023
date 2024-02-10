using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class EngineCantSpeedUpException : Exception
{
    public EngineCantSpeedUpException() { }

    public EngineCantSpeedUpException(string message)
        : base(message) { }

    public EngineCantSpeedUpException(string message, Exception innerException)
        : base(message, innerException) { }
}