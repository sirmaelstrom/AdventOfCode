namespace AdventOfCodeCommon.Interfaces;

public interface IEntryPoint
{
    void Run();
    string Calculate(string[] input);
    string[] ReadFile();
}