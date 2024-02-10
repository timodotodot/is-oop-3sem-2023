namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageIsReadException : System.Exception
{
    public MessageIsReadException() { }

    public MessageIsReadException(string message)
        : base(message) { }

    public MessageIsReadException(string message, System.Exception innerException)
        : base(message, innerException) { }
}