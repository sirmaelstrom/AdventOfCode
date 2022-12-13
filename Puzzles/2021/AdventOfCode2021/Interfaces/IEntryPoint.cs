namespace AdventOfCode2021.Interfaces;

public interface IEntryPoint
{
    void Run();
    string Calculate(string[] input);
    string[] ReadFile();
}