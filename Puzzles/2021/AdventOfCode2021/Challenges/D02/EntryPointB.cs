using AdventOfCode2021.Interfaces;

namespace AdventOfCode2021.Challenges.D02;

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
        foreach (var s in input)
        {
            ProcessCourse(s);
        }
        
        var result = _horizontal * _depth;
        return result.ToString();
    }

    private static int _aim;
    private static int _horizontal;
    private static int _depth;

    private static void ProcessCourse(string input)
    {
        var components = input.Split(" ");
        var movement = components[0];

        if (!int.TryParse(components[1], out var value))
            throw new ArgumentException("Invalid input");

        switch (movement)
        {
            case "forward":
                _horizontal += value;
                _depth += _aim * value;
                break;
            case "down":
                _aim += value;
                break;
            case "up":
                _aim -= value;
                break;
        }
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/D02/input.txt"));
}