using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day07;

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
        var dirs = Day7Parser.GenerateDirectorySizeDictionary(input);

        return dirs.Values.Select(v => v.Values.Sum())
            .Where(x => x <= 100_000)
            .Sum()
            .ToString();
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day07/input.txt"));
}

