using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Logger : ILogger
{
    private static ILogger? _instance;
    private List<string> _logsMessages;

    private Logger()
    {
        _logsMessages = new List<string>();
    }

    public static ILogger Instance
    {
        get
        {
            if (_instance is null)
            {
                _instance = new Logger();
            }

            return _instance;
        }
    }

    public void LogMessage(string sender, Message message)
    {
        if (message is null || sender is null)
        {
            throw new MessageMissingException("Message or recipient is null");
        }

        _logsMessages.Add($"From: {sender}, Title: {message.Title}");
    }

    public void GetLogs()
    {
        foreach (string log in _logsMessages)
        {
            Console.WriteLine(log);
        }
    }
}