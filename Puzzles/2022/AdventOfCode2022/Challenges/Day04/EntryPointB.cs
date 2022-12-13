using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day04;

public class EntryPointB : IEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public string Calculate(string[] input)
    {
        var result = input.Select(RangeOverlap).Sum();
        return result.ToString();
    }
    
    private static int RangeOverlap(string input)
    {
        var rangeData = Parsers.ParseRangeInput(input);

        return (rangeData[0] <= rangeData[2] && rangeData[2] <= rangeData[1])
               || (rangeData[2] <= rangeData[0] && rangeData[0] <= rangeData[3])
            ? 1
            : 0;
    }
    
    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day04/input.txt"));
}