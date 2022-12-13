using AdventOfCodeCommon.Attributes;
using AdventOfCodeCommon.Interfaces;
using AdventOfCodeCommon.Models;
using SuperLinq;

namespace AdventOfCode2021.Challenges.D01;

[Puzzle(2021, 1, CodeType.Original)]
public class Day01Original : IPuzzle
{
    public (string, string) Solve(PuzzleInput input)
    {
        var depths = input.Lines.Select(int.Parse);

        var enumerable = depths as int[] ?? depths.ToArray();
        
        var part1 = enumerable
            .Window(2)
            .Count(x => x.Last() > x.First())
            .ToString();

        var part2 = enumerable
            .Window(4)
            .Count(x => x.Last() > x.First())
            .ToString();

        return (part1, part2);
    }
}