using AdventOfCodeCommon.Extensions;

namespace AdventOfCodeCommon;

public static class ConsoleBoilerplate
{
    public static void PrintHeader(int defaultPadding = 100) {
        Console.WriteLine("Advent of Code".PadBoth(defaultPadding, '-'));
        Console.WriteLine($"{AppDomain.CurrentDomain.FriendlyName.PadBoth(defaultPadding, '+')}");
    }

    public static void PrintFooter(int defaultPadding = 100)
    {
        Console.WriteLine("fin".PadBoth(defaultPadding, '-'));
    }
}