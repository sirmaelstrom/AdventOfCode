using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day07;

public class EntryPointD : IEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public string Calculate(string[] input)
    {
        var tree = Day7Parser.GenerateDirectoryDictionaryTree(input);
        
        var part1 = tree
            .Where(x => x.Value.Size < 100_000)
            .Sum(x => x.Value.Size);
        
        var diskSpace = 70_000_000;
        var requiredSpace = 30_000_000;
        var usedSpace = tree["/"].Size;
        var spaceToFreeUp = requiredSpace - (diskSpace - usedSpace);
        var directories = tree.Values.OrderBy(x => x.Size);
        var part2 = directories.First(x => x.Size >= spaceToFreeUp).Size;
        
        var result = $"Part 1: {part1}\nPart 2: {part2}";

        return result;
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day07/input.txt"));
}