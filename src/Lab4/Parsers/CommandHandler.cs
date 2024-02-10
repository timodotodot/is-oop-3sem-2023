using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class CommandHandler
{
    private static CommandHandler? _instance;
    private Dictionary<string, Func<string[], ICommand>> _commandFactories = new Dictionary<string, Func<string[], ICommand>>(StringComparer.OrdinalIgnoreCase);

    public static CommandHandler Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new CommandHandler();
            }

            return _instance;
        }
    }

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
        else if (_commandFactories.TryGetValue(commandType + " " + commandArgs[1], out commandFactory))
        {
            ICommand command = commandFactory(commandArgs[2..]);
            command.Execute();
        }
        else
        {
            Console.WriteLine($"Неизвестная команда: {commandType}");
        }
    }
}