using AdventOfCode2021.Interfaces;

namespace AdventOfCode2021.Challenges.D01;

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
        var result =  input.Sum(CountDepthIncrease);
        return result.ToString();
    }

    private static int _lastVal;

    private static int CountDepthIncrease(string input)
    {
        if (!int.TryParse(input, out var curVal))
            throw new ArgumentException("Invalid input");
        
        if (_lastVal == default)
        {
            _lastVal = curVal;    
            return 0;
        }

        var depthIncrease = _lastVal < curVal;

        _lastVal = curVal;

        return depthIncrease ? 1 : 0;

    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/D01/input.txt"));
}