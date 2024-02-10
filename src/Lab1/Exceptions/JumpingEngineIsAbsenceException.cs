using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class JumpingEngineIsAbsenceException : ArgumentNullException
{
    public JumpingEngineIsAbsenceException() { }

    public JumpingEngineIsAbsenceException(string message)
        : base(message) { }

    public JumpingEngineIsAbsenceException(string message, Exception innerException)
        : base(message, innerException) { }
}