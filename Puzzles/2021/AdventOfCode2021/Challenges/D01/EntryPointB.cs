using AdventOfCode2021.Interfaces;

namespace AdventOfCode2021.Challenges.D01;

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
        var slidingData = new List<int>();

        var rowNumber = 0;
        while (rowNumber < input.Length - 2)
        {
            var group = input
                .Skip(rowNumber)
                .Take(3)
                .Select(int.Parse)
                .Sum();
            slidingData.Add(group);
            rowNumber++;
        }

        var result = slidingData.Sum(CountDepthIncrease);
        
        return result.ToString();
    }

    private static int _lastVal;
    
    private static int CountDepthIncrease(int input)
    {
        if (_lastVal == default)
        {
            _lastVal = input;    
            return 0;
        }

        var depthIncrease = _lastVal < input;

        _lastVal = input;

        return depthIncrease ? 1 : 0;
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/D01/input.txt"));
}