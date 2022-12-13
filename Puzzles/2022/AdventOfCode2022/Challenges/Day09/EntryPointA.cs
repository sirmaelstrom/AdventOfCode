using AdventOfCode2022.Challenges.Day09;
using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day09;

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
        return Parser.RunInstructions(input, 2).ToString();
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day09/input.txt"));
}