using AdventOfCodeCommon.Models;

namespace AdventOfCodeCommon.Interfaces;

public interface IPuzzle
{
	(string part1, string part2) Solve(PuzzleInput input);
}
