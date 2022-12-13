namespace AdventOfCode2022.Challenges.D11;

public class EntryPointB
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input, null);
        Console.WriteLine(result);
    }

    public string Calculate(string[] input, IReadOnlyList<Func<long, long>>? operations)
    {
        operations ??= Parser.Operations;
        return Parser.CalculatePart2(input, operations);
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/D11/input.txt"));
}