namespace AdventOfCodeCommon.Extensions;

public static class StringExtensions
{
    public static string PadBoth(this string str, int length, char paddingChar = ' ')
    {
        var spaces = length - str.Length;
        var padLeft = spaces / 2 + str.Length;
        return str.PadLeft(padLeft, paddingChar).PadRight(length, paddingChar);
    }
}