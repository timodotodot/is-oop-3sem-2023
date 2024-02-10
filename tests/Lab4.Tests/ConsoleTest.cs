using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using NUnit.Framework;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

[TestFixture]
public class ConsoleTest
{
    [Test]
    public void DeleteFile()
    {
        // Arrange
        string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(path);

        string filePath = Path.Combine(path, "yolo.txt");
        File.WriteAllText(filePath, "Hello, world!");

        CommandHandler parser = CommandHandler.Instance;
        parser.RegisterCommand("file delete", args => new DeleteFile(args[0]));
        string command = $"file delete {filePath}";
        string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Act
        parser.ProcessCommand(commandArgs);

        // Assert
        Assert.IsFalse(File.Exists(filePath));
        Assert.IsTrue(Directory.Exists(path));
    }

    [Test]
    public void RenameFile()
    {
        // Arrange
        string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(path);

        string filePath = Path.Combine(path, "yolo.txt");
        string renameFilePath = Path.Combine(path, "super.txt");
        File.WriteAllText(filePath, "Hello, world!");

        CommandHandler parser = CommandHandler.Instance;
        parser.RegisterCommand("file rename", args => new RenameFile(args[0], args[1]));
        string command = $"file rename {filePath} {renameFilePath}";
        string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Act
        parser.ProcessCommand(commandArgs);

        // Assert
        Assert.IsFalse(File.Exists(filePath));
        Assert.IsTrue(File.Exists(renameFilePath));
        Assert.IsTrue(Directory.Exists(path));
    }
}