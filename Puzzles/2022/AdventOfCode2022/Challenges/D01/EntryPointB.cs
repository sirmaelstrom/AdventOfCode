using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.D01;

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
        var groups = new List<List<int>>();
        var rowNumber = 0;
        while (rowNumber < input.Length)
        {
            var group = input
                .Skip(rowNumber)
                .TakeWhile(x => x != string.Empty)
                .Select(int.Parse)
                .ToList();
            groups.Add(group);
            rowNumber += group.Count + 1;
        }

        var sum = groups.Select(x => x.Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
        return sum.ToString();
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/D01/input.txt"));
}