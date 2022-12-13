using AdventOfCode2022.Challenges.Day10;
using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day10;

public class EntryPointA : IEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public string Calculate(string[] input)
    {
        return Parser.CalculateSignalStrength(input);
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day10/input.txt"));
}