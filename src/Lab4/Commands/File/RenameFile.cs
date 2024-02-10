using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class RenameFile : ICommand
{
    private string _path;
    private string _newName;

    public RenameFile(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public void Execute()
    {
        try
        {
            if (System.IO.File.Exists(_path))
            {
                System.IO.File.Move(_path, _newName);
                Console.WriteLine($"File '{_path}' renamed to '{_newName}'");
            }
            else
            {
                Console.WriteLine($"File {_path} is missing");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}