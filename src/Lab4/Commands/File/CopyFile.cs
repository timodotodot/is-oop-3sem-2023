using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class CopyFile : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public CopyFile(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute()
    {
        try
        {
            if (System.IO.File.Exists(_sourcePath))
            {
                System.IO.File.Copy(_sourcePath, _destinationPath);
                Console.WriteLine($"Copy file {_sourcePath} to {_destinationPath}");
            }
            else
            {
                Console.WriteLine($"File {_sourcePath} is missing");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}