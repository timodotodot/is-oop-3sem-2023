namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class ObjectIsNullException : System.Exception
{
    public ObjectIsNullException() { }

    public ObjectIsNullException(string message)
        : base(message) { }

    public ObjectIsNullException(string message, System.Exception innerException)
        : base(message, innerException) { }
}