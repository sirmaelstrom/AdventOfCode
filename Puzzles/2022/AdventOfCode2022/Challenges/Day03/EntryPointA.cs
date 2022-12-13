using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day03;

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
        var result = input.Sum(CountPriority);
        return result.ToString();
    }
    
    private static int CountPriority(string input)
    {
        var mid = input.Length / 2;
        var bag1 = input.Substring(0, mid);
        var bag2 = input.Substring(mid, mid);

        var intersection = bag1.Intersect(bag2).First();

        var append = Char.IsUpper(intersection) ? 26 : 0;
        
        return intersection % 32 + append;
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day03/input.txt"));
}