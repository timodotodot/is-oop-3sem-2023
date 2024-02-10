namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class ModelMissingException : System.Exception
{
    public ModelMissingException() { }

    public ModelMissingException(string message)
        : base(message) { }

    public ModelMissingException(string message, System.Exception innerException)
        : base(message, innerException) { }
}