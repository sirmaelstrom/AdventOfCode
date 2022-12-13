namespace AdventOfCode2022.Challenges.D11;

public class EntryPointA
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input, null);
        Console.WriteLine(result);
    }

    public static string Calculate(IEnumerable<string> input, IReadOnlyList<Func<long, long>>? operations)
    {
        operations ??= Parser.Operations;
        return Parser.CalculatePart1(input, operations);
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/D11/input.txt"));
}