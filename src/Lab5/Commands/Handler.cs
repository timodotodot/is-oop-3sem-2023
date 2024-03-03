using Itmo.ObjectOrientedProgramming.Abstraction;

namespace Commands;

public class Handler
{
    private Dictionary<string, Func<string[], ICommand>> _commandFactories = new Dictionary
        <string, Func<string[], ICommand>>(StringComparer.OrdinalIgnoreCase);

    public void RegisterCommand(string commandType, Func<string[], ICommand> commandFactory)
    {
        _commandFactories[commandType] = commandFactory;
    }

    public void ProcessCommand(string[] commandArgs)
    {
        if (commandArgs is null || commandArgs.Length == 0)
        {
            return;
        }

        string commandType = commandArgs[0];

        if (_commandFactories.TryGetValue(commandType, out Func<string[], ICommand>? commandFactory))
        {
            ICommand command = commandFactory(commandArgs[1..]);
            command.Execute();
        }
        else
        {
            Console.WriteLine($"Неизвестная команда: {commandType}");
        }
    }
}