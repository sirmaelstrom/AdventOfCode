using System.Diagnostics;
using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day07;

public class EntryPointC : IEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public string Calculate(string[] input)
    {
        var root = new FolderNode { Name = "/" };
        Day7Parser.GenerateDirectoryNodes(input, root);

        // Calculate Part 1
        var smallerFolders = new List<FolderNode>();
        
        Debug.Assert(root != null, nameof(root) + " != null");
        var toCheck = root.GetSubFolders();

        while (toCheck.Count > 0)
        {
            var folder = toCheck.First();
            toCheck.AddRange(folder.GetSubFolders());
            if(folder.GetSize() <= 100_000)
                smallerFolders.Add(folder);

            toCheck.RemoveAt(0);
        }

        var part1 = smallerFolders.Aggregate(0, (current, f) => (int)(current + f.GetSize()));

        // Calculate Part 2
        var totalSpace = 70_000_000;
        var freeSpace = totalSpace - root.GetSize();

        var part2 = long.MaxValue;
        toCheck = root.GetSubFolders();

        while (toCheck.Count > 0)
        {
            var folder = toCheck.First();
            toCheck.AddRange(folder.GetSubFolders());
            var size = folder.GetSize();
            if (freeSpace + size > 30_000_000 && size < part2)
                part2 = size;
            
            toCheck.RemoveAt(0);
        }
        
        var result = $"Part 1: {part1}\nPart 2: {part2}";

        return result;
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day07/input.txt"));
}