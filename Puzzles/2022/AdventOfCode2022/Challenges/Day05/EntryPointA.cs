using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day05;

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
        var stackDrawing = input.ExtractStackDrawing();
        var stacks = stackDrawing.ConvertStackDrawingToStacks();
        var orders = input.GenerateOrdersEnumerable();

        foreach (var order in orders)
        {
            order.MoveBoxes(stacks);
        }

        var result = stacks.Select(queue => queue.Peek());
        return string.Join(null, result);
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day05/input.txt"));
}