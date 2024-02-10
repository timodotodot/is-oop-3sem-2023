namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class WrongTypeObjectException : System.Exception
{
    public WrongTypeObjectException() { }

    public WrongTypeObjectException(string message)
        : base(message) { }

    public WrongTypeObjectException(string message, System.Exception innerException)
        : base(message, innerException) { }
}