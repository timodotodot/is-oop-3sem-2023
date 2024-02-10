using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class MoveFile : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public MoveFile(string sourcePath, string destinationPath)
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
                System.IO.File.Move(_sourcePath, _destinationPath);
                Console.WriteLine($"File '{_sourcePath}' is moved in '{_destinationPath}'");
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