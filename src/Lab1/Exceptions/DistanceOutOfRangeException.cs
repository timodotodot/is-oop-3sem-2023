using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class DistanceOutOfRangeException : Exception
{
    public DistanceOutOfRangeException() { }

    public DistanceOutOfRangeException(string message)
        : base(message) { }

    public DistanceOutOfRangeException(string message, Exception innerException)
        : base(message, innerException) { }
}