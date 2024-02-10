using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class Topic
{
    public Topic(string name, IRecipient recipient, Message message)
    {
        Name = name;
        Recipient = recipient;
        Message = message;
    }

    public string Name { get; private set; }
    public IRecipient Recipient { get; private set; }
    public Message Message { get; set; }
}