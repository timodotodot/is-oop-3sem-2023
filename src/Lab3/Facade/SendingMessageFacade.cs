using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Facade;

public static class SendingMessageFacade
{
    public static void FromTopicToRecipient(Topic topic, IRecipient recipient, ILogger logger)
    {
        if (topic is null || recipient is null || logger is null)
        {
            throw new ObjectIsNullException("Object in Facade is null");
        }

        recipient.TakeMessage(topic.Message);
        logger.LogMessage(recipient.Id, topic.Message);
    }

    public static void FromUser1ToUser2(Message message, User user1, User user2, ILogger logger)
    {
        if (message is null || user1 is null || user2 is null || logger is null)
        {
            throw new ObjectIsNullException("Object in Facade is null");
        }

        user1.SendMessage(user2, message);
        logger.LogMessage(user1.Id, message);
    }
}