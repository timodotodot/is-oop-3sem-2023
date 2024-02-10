using System;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.File;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;
using Itmo.ObjectOrientedProgramming.Lab4.Model;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CommandHandler parser = CommandHandler.Instance;

        parser.RegisterCommand("connect", args => new ConnectDirectory(args[0], args[2]));
        parser.RegisterCommand("disconnect", _ => new DisconnectDirectory());

        parser.RegisterCommand("tree goto", args => new GotoTree(args[0]));
        parser.RegisterCommand("tree list", args => new ListTree(args[1]));

        parser.RegisterCommand("file copy", args => new CopyFile(args[0], args[1]));
        parser.RegisterCommand("file delete", args => new DeleteFile(args[0]));
        parser.RegisterCommand("file rename", args => new RenameFile(args[0], args[1]));
        parser.RegisterCommand("file show", args => new ShowFile(args[0], args[2]));
        parser.RegisterCommand("file move", args => new MoveFile(args[0], args[1]));
        string? command = " ";

        while (true)
        {
            Console.WriteLine(" ");
            Console.Write($"{DataInfo.CurrentDirectory} >>> ");
            command = Console.ReadLine();

            if (command == "exit")
            {
                break;
            }

            if (command is not null)
            {
                string[] commandArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                parser.ProcessCommand(commandArgs);
            }
        }
    }
}