using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Types;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User : IRecipient
{
    private List<(Message, bool)> _incomingMessages; // Item1 - это наше сообщение, Item2 - статус Прочитано(true)/Не прочитано(false)
    private List<Message> _sentMessages;
    private List<ImportanceLevel> _importanceLevels;

    public User(string id)
    {
        _incomingMessages = new List<(Message, bool)>();
        _sentMessages = new List<Message>();
        _importanceLevels = new List<ImportanceLevel>();

        Id = id;
    }

    public virtual string Id { get; set; }

    public virtual void SendMessage(User user, Message message)
    {
        user?.TakeMessage(message);
        _sentMessages.Add(message);
    }

    public virtual void TakeMessage(Message message)
    {
        foreach (ImportanceLevel level in _importanceLevels)
        {
            if (message?.Importance == level)
            {
                _incomingMessages.Add((message, false));
            }
        }
    }

    public virtual void FilterImportanceLevel(ImportanceLevel importanceLevel)
    {
        _importanceLevels.Add(importanceLevel);
    }

    public virtual void ReadMessage(string message)
    {
        foreach ((Message, bool) thisMessage in _incomingMessages)
        {
            if (thisMessage.Item1.Title == message)
            {
                if (thisMessage.Item2)
                {
                    throw new MessageIsReadException("You cannot mark as read a message that has already been read.");
                }

                int index = _incomingMessages.IndexOf(thisMessage);
                _incomingMessages[index] = new(thisMessage.Item1, true);

                break;
            }
        }
    }

    public virtual bool GetStatusMessage(string title)
    {
        foreach ((Message, bool) thisTitle in _incomingMessages)
        {
            if (thisTitle.Item1.Title == title)
            {
                return thisTitle.Item2;
            }
        }

        throw new MessageMissingException($"User didn't have this message: {title}");
    }

    public virtual IEnumerable<(Message Message, bool IsRead)> GetIncomingMessages(string title)
    {
        return _incomingMessages.Where(message => message.Item1.Title == title);
    }
}