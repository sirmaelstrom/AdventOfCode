using System;
using System.IO;

namespace AdventOfCode.Runner;

public static class BenchmarkInputProvider
{
	public static PuzzleInput GetRawInput(int year, int day, string test = "")
	{
		//var inputFile = @$"..\..\..\..\..\..\..\Inputs\{year}\day{day:00}.input.txt";

		var inputFile = Path.Combine(Environment.CurrentDirectory,
			@$"..\..\..\..\..\..\Puzzles\{year}\AdventOfCode{year}\Challenges\D{day:00}/{test}input.txt");

		return new PuzzleInput(
			File.ReadAllBytes(inputFile),
			File.ReadAllText(inputFile),
			File.ReadAllLines(inputFile));
	}
}
