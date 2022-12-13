using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day06;

public class EntryPointB : IEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    private const int BufferSize = 14;

    public string Calculate(string[] input)
    {
        return input.Solve(BufferSize);
    }
    
    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day06/input.txt"));
}