using AdventOfCodeCommon;
using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day07;

public class EntryPointE : IEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public string Calculate(string[] input)
    {
        // 640k should be enough for anyone
        Span<int> sizes = stackalloc int[256];
        var sizesIndex = 0;
        Span<int> stack = stackalloc int[16];
        var stackIndex = 0;
        var currentSize = 0;
        
        foreach (var l in input)
        {
            if (l.Equals("$ cd ..", StringComparison.Ordinal))
            {
                sizes[sizesIndex++] = currentSize;
                currentSize += stack[--stackIndex];
            }
            else if (l.StartsWith("$ cd ", StringComparison.Ordinal))
            {
                stack[stackIndex++] = currentSize;
                currentSize = 0;
            }
            else if (l[0] is >= '0' and <= '9')
            {
                var (size, _) = l.AsSpan().AtoI();
                currentSize += size;
            }
        }

        while (stackIndex > 0)
        {
            sizes[sizesIndex++] = currentSize;
            currentSize += stack[--stackIndex];
        }

        sizes[sizesIndex] = currentSize;
        sizes = sizes[..(sizesIndex + 1)];

        var needed = sizes[sizesIndex] - 40_000_000;
        var part1 = 0;
        var part2 = int.MaxValue;
        foreach (var s in sizes)
        {
            if (s < 100_000)
                part1 += s;
            if (s >= needed && s < part2)
                part2 = s;
        }
        
        var result = $"Part 1: {part1}\nPart 2: {part2}";
        return result;
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day07/input.txt"));
}