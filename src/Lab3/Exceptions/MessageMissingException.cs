namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class MessageMissingException : System.Exception
{
    public MessageMissingException() { }

    public MessageMissingException(string message)
        : base(message) { }

    public MessageMissingException(string message, System.Exception innerException)
        : base(message, innerException) { }
}