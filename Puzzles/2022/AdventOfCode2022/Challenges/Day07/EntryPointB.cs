using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day07;

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
        var dirs = Day7Parser.GenerateDirectorySizeDictionary(input);

        var unused = 70_000_000 - dirs["/"].Values.Sum();
        var needed = 30_000_000 - unused;

        return dirs.Values.Select(v => v.Values.Sum())
            .Where(x => x >= needed)
            .Min()
            .ToString();
    }
    
    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day07/input.txt"));
}