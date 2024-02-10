using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Types;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public class Messenger : IRecipient
{
    private List<Message> _messages;
    private List<ImportanceLevel> _importanceLevels;

    public Messenger(string id)
    {
        _messages = new List<Message>();
        _importanceLevels = new List<ImportanceLevel>();

        Id = id;
    }

    public string Id { get; set; }

    public virtual void TakeMessage(Message message)
    {
        foreach (ImportanceLevel level in _importanceLevels)
        {
            if (message?.Importance == level)
            {
                _messages.Add(message);
            }
        }
    }

    public virtual void FilterImportanceLevel(ImportanceLevel importanceLevel)
    {
        _importanceLevels.Add(importanceLevel);
    }

    public virtual void OutputMessages()
    {
        foreach (Message message in _messages)
        {
            Console.WriteLine($"Title: {message.Title}, Body: {message.Body}");
        }
    }
}