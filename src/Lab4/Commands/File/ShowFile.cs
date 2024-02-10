using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.File;

public class ShowFile : ICommand
{
    private string _path;
    private string _mode;

    public ShowFile(string path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public void Execute()
    {
        try
        {
            switch (_mode)
            {
                case "console":
                    if (System.IO.File.Exists(_path))
                    {
                        Console.WriteLine("File contents: ");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine(System.IO.File.ReadAllText(_path));
                        Console.WriteLine("---------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"File {_path} is missing");
                    }

                    break;

                default:
                    Console.WriteLine("Invalid mode");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}