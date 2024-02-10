using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class DeleteFile : ICommand
{
    private string _path;

    public DeleteFile(string path)
    {
        _path = path;
    }

    public void Execute()
    {
        try
        {
            if (System.IO.File.Exists(_path))
            {
                System.IO.File.Delete(_path);
                Console.WriteLine($"File {_path} is deleted");
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