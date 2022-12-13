namespace AdventOfCodeCommon.Interfaces;

public interface IByteArrayEntryPoint
{
    abstract void Run();
    abstract string Calculate(byte[] input);
    abstract byte[] ReadFile();
}