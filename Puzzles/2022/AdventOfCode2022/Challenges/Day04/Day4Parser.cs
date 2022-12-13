namespace AdventOfCode2022.Challenges.Day04;

internal static class Parsers
{
    internal static int[] ParseRangeInput(string input)
    {
        var numbers = input
            .Split(",")
            .SelectMany(x => x.Split("-"))
            .Select(int.Parse).ToArray();

        if (numbers.Length != 4)
            throw new ArgumentException("Invalid input");

        return numbers;
    }
}