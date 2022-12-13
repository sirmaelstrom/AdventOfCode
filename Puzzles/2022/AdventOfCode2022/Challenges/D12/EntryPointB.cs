using AdventOfCodeCommon;
using AdventOfCodeCommon.Interfaces;
using SuperLinq;

namespace AdventOfCode2022.Challenges.D12;

public class EntryPointB : IByteArrayEntryPoint
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
        
        var part2 = int.MaxValue;
        var start = (x: 0, y: 0);
        var end = start;
        for (var y = 0; y < map.Length; y++)
        for (var x = 0; x < map[y].Length; x++)
            if (map[y][x] == (byte)'E')
            {
                end = (x, y);
            }
        
        map[start.y][start.x] = (byte)'a';
        map[end.y][end.x] = (byte)'z';
        
        for (var y = 0; y < map.Length; y++)
        for (var x = 0; x < map[y].Length; x++)
            if (map[y][x] == (byte)'a')
            {
                try
                {
                    var curCost = SuperEnumerable.GetShortestPathCost<(int x, int y), int>(
                        (x, y),
                        (p, c) => p.GetCartesianNeighbors(map)
                            .Where(q => map[q.y][q.x] - map[p.y][p.x] <= 1)
                            .Select(q => (q, c + 1)),
                        end);
                    if (curCost < part2)
                        part2 = curCost;
                }
                catch
                {
                    // ignored
                }
            }
        
        return part2.ToString();
    }

    public byte[] ReadFile() => File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/D12/input.txt"));
}