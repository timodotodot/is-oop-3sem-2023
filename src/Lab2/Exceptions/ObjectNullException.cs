namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ObjectNullException : System.Exception
{
    public ObjectNullException() { }

    public ObjectNullException(string message)
        : base(message) { }

    public ObjectNullException(string message, System.Exception innerException)
        : base(message, innerException) { }
}