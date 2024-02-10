using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public interface ILogger
{
    public void LogMessage(string sender, Message message);
}