using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Group
{
    private List<IRecipient> _recipients;

    public Group()
    {
        _recipients = new List<IRecipient>();
    }

    public void AddRecipients(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void TakeMessage(Message message)
    {
        for (int i = 0; i < _recipients.Count; ++i)
        {
            _recipients[i].TakeMessage(message);
        }
    }
}