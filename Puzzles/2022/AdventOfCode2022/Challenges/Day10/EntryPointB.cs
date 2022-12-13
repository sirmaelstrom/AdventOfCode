using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day10;

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
        return Parser.DrawScreen(input);
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day10/input.txt"));
}