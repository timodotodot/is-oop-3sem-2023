using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Model;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Tree;

public class ListTree : ICommand
{
    private int _newDepth;

    public ListTree(string newDepth)
    {
        _newDepth = int.Parse(newDepth, new CultureInfo("en-US"));
    }

    public void Execute()
    {
        DataInfo.DepthSampling = _newDepth;
    }
}