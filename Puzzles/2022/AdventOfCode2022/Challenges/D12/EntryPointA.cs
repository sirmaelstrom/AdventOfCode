using AdventOfCodeCommon;
using AdventOfCodeCommon.Interfaces;
using SuperLinq;

namespace AdventOfCode2022.Challenges.D12;

public class EntryPointA : IByteArrayEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public string Calculate(byte[] input)
    {
        var map = input.GetMap();
        
        var start = (x: 0, y: 0);
        var end = start;
        for (var y = 0; y < map.Length; y++)
        for (var x = 0; x < map[y].Length; x++)
            switch (map[y][x])
            {
                case (byte)'S':
                    start = (x, y);
                    break;
                case (byte)'E':
                    end = (x, y);
                    break;
            }

        map[start.y][start.x] = (byte)'a';
        map[end.y][end.x] = (byte)'z';

        var cost = SuperEnumerable.GetShortestPathCost<(int x, int y), int>(
            start,
            (p, c) => p.GetCartesianNeighbors(map)
                .Where(q => map[q.y][q.x] - map[p.y][p.x] <= 1)
                .Select(q => (q, c + 1)),
            end);

        var part1 = cost.ToString();

        return part1;
    }

    public byte[] ReadFile() => File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/D12/input.txt"));
}