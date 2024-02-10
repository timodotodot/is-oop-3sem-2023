using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Types;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Display : IRecipient
{
    private Message? _message;
    private List<ImportanceLevel> _importanceLevels;

    public Display(string id)
    {
        _importanceLevels = new List<ImportanceLevel>();
        Id = id;
    }

    public string Id { get; set; }

    public void FilterImportanceLevel(ImportanceLevel importanceLevel)
    {
        _importanceLevels.Add(importanceLevel);
    }

    public void TakeMessage(Message message)
    {
        foreach (ImportanceLevel level in _importanceLevels)
        {
            if (message?.Importance == level)
            {
                _message = message;
            }
        }
    }

    public void OutputMessage(ConsoleColor color)
    {
        if (_message is null)
        {
            throw new MessageMissingException("Message is null");
        }

        DisplayDriver.ClearDisplay();
        DisplayDriver.SetTextColor(color);
        DisplayDriver.WriteText(_message);
    }
}