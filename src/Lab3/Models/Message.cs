using Itmo.ObjectOrientedProgramming.Lab3.Types;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public class Message
{
    public Message(string title, string body, ImportanceLevel importance)
    {
        Title = title;
        Body = body;
        Importance = importance;
    }

    public virtual string Title { get; private set; }
    public virtual string Body { get; private set; }
    public virtual ImportanceLevel Importance { get; set; }
}