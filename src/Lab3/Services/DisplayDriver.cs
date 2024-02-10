using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services;

public static class DisplayDriver
{
    public static void ClearDisplay()
    {
        Console.Clear();
    }

    public static void SetTextColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public static void WriteText(Message message)
    {
        Console.WriteLine($"{message?.Title}");
        Console.WriteLine($"{message?.Body}");
    }
}