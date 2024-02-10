namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class MissingAttributeException : System.Exception
{
    public MissingAttributeException() { }

    public MissingAttributeException(string message)
        : base(message) { }

    public MissingAttributeException(string message, System.Exception innerException)
        : base(message, innerException) { }
}