using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Facade;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services;
using Itmo.ObjectOrientedProgramming.Lab3.Types;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Lab3Tests
{
    [Fact]
    public void MessageMustHaveNotReadStatus()
    {
        // Avarange
        ILogger logger = Logger.Instance;

        var message = new Message("Hello, world!", "I make my first message", ImportanceLevel.Low);
        var user = new User("Grigoriy");
        var topic = new Topic("Topic #1", user, message);
        user.FilterImportanceLevel(ImportanceLevel.Low);

        // Act
        SendingMessageFacade.FromTopicToRecipient(topic, user, logger);
        bool expectedResult = false;
        bool result = user.GetStatusMessage("Hello, world!");

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ReadMessageMustHaveStatusReaded()
    {
        // Avarange
        ILogger logger = Logger.Instance;

        var message = new Message("Hello, world!", "I make my first message", ImportanceLevel.Low);
        var user = new User("Grigoriy");
        var topic = new Topic("Topic #1", user, message);
        user.FilterImportanceLevel(ImportanceLevel.Low);

        // Act
        SendingMessageFacade.FromTopicToRecipient(topic, user, logger);
        user.ReadMessage("Hello, world!");
        bool expectedResult = true;
        bool result = user.GetStatusMessage("Hello, world!");

        // Assert
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void ReadedMessageChangeStatusOnRead()
    {
        // Avarange
        ILogger logger = Logger.Instance;

        var message = new Message("Hello, world!", "I make my first message", ImportanceLevel.Low);
        var user = new User("Grigoriy");
        var topic = new Topic("Topic #1", user, message);
        user.FilterImportanceLevel(ImportanceLevel.Low);

        // Act
        SendingMessageFacade.FromTopicToRecipient(topic, user, logger);
        user.ReadMessage("Hello, world!");

        // Assert
        Assert.Throws<MessageIsReadException>(() => user.ReadMessage("Hello, world!"));
    }

    /*[Fact]
    public void UserDoesNotTakeMessageBelowLevel()
    {
        // Avarange
        var user = new Mock<User>("Grigoriy");
        user.Object.FilterImportanceLevel(ImportanceLevel.Medium);
        var message = new Mock<Message>("Testing", "Hello, world!", ImportanceLevel.Low);

        // Act
        user.Setup(u => u.TakeMessage(It.IsAny<Message>())).Callback<Message>(msg =>
        {
            Assert.Equal(ImportanceLevel.Low, msg.Importance);
        });
        user.Object.SendMessage(user.Object, message.Object);

        // Assert
        Assert.Empty(user.Object.GetIncomingMessages("Testing"));
    }

    [Fact]
    public void MessengerAddsMessageWhenSent()
    {
        // Avarange
        var messenger = new Mock<Messenger>("Messenger1");
        var message = new Message("Testing", "Hello, world!", ImportanceLevel.Medium);

        // Act
        messenger.Object.TakeMessage(message);

        // Assert
        messenger.Verify(m => m.TakeMessage(It.Is<Message>(msg => msg == message)), Times.Once);
    }

    [Fact]
    public void LoggerLogsMessageWhenConfigured()
    {
        // Avarange
        var logger = new Mock<ILogger>();
        var messenger = new Messenger("Messenger1");
        var message = new Message("Testing", "Hello, world!", ImportanceLevel.Medium);

        // Act
        messenger.TakeMessage(message);
        logger.Object.LogMessage(messenger.Id, message);

        // Assert
        logger.Verify(l => l.LogMessage("Messenger1", message), Times.Once);
    }*/
}