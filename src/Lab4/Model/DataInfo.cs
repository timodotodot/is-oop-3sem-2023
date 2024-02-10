using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Model;

public static class DataInfo
{
    public static string CurrentDirectory { get; set; } = Directory.GetCurrentDirectory();
    public static string StartDirectory { get; } = Directory.GetCurrentDirectory();

    public static int DepthSampling { get; set; } = 256;
}