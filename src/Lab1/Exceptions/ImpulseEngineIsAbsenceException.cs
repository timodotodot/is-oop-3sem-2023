using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ImpulseEngineIsAbsenceException : ArgumentNullException
{
    public ImpulseEngineIsAbsenceException() { }

    public ImpulseEngineIsAbsenceException(string message)
        : base(message) { }

    public ImpulseEngineIsAbsenceException(string message, Exception innerException)
        : base(message, innerException) { }
}