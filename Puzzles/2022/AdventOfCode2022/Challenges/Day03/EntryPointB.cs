using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day03;

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
        var groups = input
            .Chunk(3)
            .ToList();

        var result = groups.Sum(CountPriority);
        return result.ToString();
    }
    
    private static int CountPriority(IList<string> input)
    {
        var bag1 = input[0];
        var bag2 = input[1];
        var bag3 = input[2];

        var intersection = bag1.Intersect(bag2).Intersect(bag3).First();

        var append = Char.IsUpper(intersection) ? 26 : 0;
        
        return intersection % 32 + append;
    }
    
    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day03/input.txt"));
}