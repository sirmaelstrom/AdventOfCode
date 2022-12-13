using System.Diagnostics;
using System.Text.Json.Nodes;
using AdventOfCodeCommon.Attributes;
using AdventOfCodeCommon.Interfaces;
using AdventOfCodeCommon.Models;

namespace AdventOfCode2022.Challenges.D13;

[Puzzle(2022, 13, CodeType.Original, "Distress Signal")]
public class Day13Original : IPuzzle
{
    public (string, string) Solve(PuzzleInput input)
    {
        var part1 = PartOne(input.Text);
        var part2 = PartTwo(input.Text); 
        return (part1, part2);
    }

    private static string PartOne(string input) =>
        GetPackets(input)
            .Chunk(2)
            .Select((pair, index) => Compare(pair[0], pair[1]) < 0 ? index + 1 : 0)
            .Sum()
            .ToString();

    private static string PartTwo(string input)
    {
        var divider = GetPackets("[[2]]\r\n[[6]]").ToList();
        var packets = GetPackets(input).Concat(divider).ToList();
        packets.Sort(Compare);
        var result = (packets.IndexOf(divider[0]) + 1) * (packets.IndexOf(divider[1]) + 1);
        return result.ToString();
    }

    private static IEnumerable<JsonNode> GetPackets(string input) =>
        from line in input.Split("\r\n")
        where !string.IsNullOrEmpty(line)
        select JsonNode.Parse(line);

    private static int Compare(JsonNode nodeA, JsonNode nodeB)
    {
        if (nodeA is JsonValue && nodeB is JsonValue)
        {
            return (int)nodeA - (int)nodeB;
        }

        var arrayA = nodeA as JsonArray ?? new JsonArray((int)nodeA);
        var arrayB = nodeB as JsonArray ?? new JsonArray((int)nodeB);
        return arrayA.Zip(arrayB)
            .Select(p =>
            {
                Debug.Assert(p.First != null, "p.First != null");
                Debug.Assert(p.Second != null, "p.Second != null");
                return Compare(p.First, p.Second);
            })
            .FirstOrDefault(c => c != 0, arrayA.Count - arrayB.Count);
    }
}