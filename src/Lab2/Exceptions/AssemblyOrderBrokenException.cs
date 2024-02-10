namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class AssemblyOrderBrokenException : System.Exception
{
    public AssemblyOrderBrokenException() { }

    public AssemblyOrderBrokenException(string message)
        : base(message) { }

    public AssemblyOrderBrokenException(string message, System.Exception innerException)
        : base(message, innerException) { }
}