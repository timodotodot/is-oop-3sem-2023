using System;
using Itmo.ObjectOrientedProgramming.Lab4.Model;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

public class GotoTree : ICommand
{
    private string _path;
    private int _depth;

    public GotoTree(string path)
    {
        _path = path;
        _depth = DataInfo.DepthSampling;
    }

    public void Execute()
    {
        Show(_path, " ");
    }

    private void Show(string path, string indent)
    {
        if (_depth < 0)
        {
            return;
        }

        try
        {
            Console.WriteLine($"{indent}\ud83d\udcc2 {System.IO.Path.GetFileName(path)}");

            string[] directories = System.IO.Directory.GetDirectories(path);
            string[] files = System.IO.Directory.GetFiles(path);

            foreach (string directory in directories)
            {
                _depth--;
                Show(directory, indent + "|  ");
            }

            foreach (string file in files)
            {
                Console.WriteLine($"{indent} \u2514\ud83d\udcc4 {System.IO.Path.GetFileName(file)}");
            }

            _depth = DataInfo.DepthSampling;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}