using System;
using Itmo.ObjectOrientedProgramming.Lab4.Model;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Directory;

public class ConnectDirectory : ICommand
{
    private string _directory;
    private string _mode;
    private string _startDirectory;

    public ConnectDirectory(string directory, string mode)
    {
        _directory = directory;
        _mode = mode;
        _startDirectory = System.IO.Directory.GetCurrentDirectory();
    }

    public void Execute()
    {
        try
        {
            if (_directory == _startDirectory)
            {
                return;
            }

            switch (_mode)
            {
                case "local":
                    System.IO.Directory.SetCurrentDirectory(_directory);
                    DataInfo.CurrentDirectory = _directory;
                    Console.WriteLine($"Success! Current directory: '{System.IO.Directory.GetCurrentDirectory()}'");
                    break;

                default:
                    Console.WriteLine("Connect mode is missing");
                    break;
            }
        }
        catch (Exception messageException)
        {
            Console.WriteLine($"Error: {messageException.Message}");
            throw;
        }
    }
}