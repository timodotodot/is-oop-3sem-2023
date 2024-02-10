using System;
using Itmo.ObjectOrientedProgramming.Lab4.Model;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Directory;

public class DisconnectDirectory : ICommand
{
    public void Execute()
    {
        try
        {
            if (System.IO.Directory.GetCurrentDirectory() == DataInfo.StartDirectory)
            {
                return;
            }

            System.IO.Directory.SetCurrentDirectory(DataInfo.StartDirectory);
            DataInfo.CurrentDirectory = DataInfo.StartDirectory;
            Console.WriteLine("You have disconnected from the file system");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}