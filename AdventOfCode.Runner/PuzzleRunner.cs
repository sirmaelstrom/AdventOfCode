using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using AdventOfCode2022.Challenges.D01;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace AdventOfCode.Runner;

public class PuzzleRunner
{
	private readonly IReadOnlyList<PuzzleModel> _puzzles;
	private readonly MethodInfo _runMethod;
	private readonly Type _benchmarkClass;

	private static readonly Assembly[] Assemblies =
	{
		Assembly.GetAssembly(typeof(AdventOfCode2021.Challenges.D01.Day01Original))!,
		Assembly.GetAssembly(typeof(Day01Original))!,
	};

	public PuzzleRunner()
	{
		_puzzles = GetAllPuzzles();
		_runMethod = GetType().GetMethod(nameof(RunPuzzle), BindingFlags.Static | BindingFlags.NonPublic)!;
		_benchmarkClass = typeof(PuzzleBenchmarkRunner<>);
	}

	public IReadOnlyCollection<PuzzleModel> GetPuzzles() => _puzzles;

	public IEnumerable<PuzzleResult> RunPuzzles(IEnumerable<PuzzleModel> puzzles) =>
		puzzles
			.Select(puzzle =>
			{
				var method = _runMethod.MakeGenericMethod(puzzle.PuzzleType);
				return (PuzzleResult)method.Invoke(null, new object[] { puzzle })!;
			});

	public Summary BenchmarkPuzzles(IEnumerable<PuzzleModel> puzzles)
	{
		var types = puzzles
			.Select(p => _benchmarkClass.MakeGenericType(p.PuzzleType))
			.ToArray();

		return BenchmarkSwitcher.FromTypes(types)
			.RunAllJoined(
				DefaultConfig.Instance
					.WithOrderer(new TypeOrderer()));
	}

	private class TypeOrderer : DefaultOrderer
	{
		public override IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCases, Summary summary) =>
			benchmarksCases
				.OrderBy(c => c.Descriptor.Type.FullName)
				.ThenBy(c => c.Descriptor.MethodIndex);
	}

	private static IReadOnlyList<PuzzleModel> GetAllPuzzles()
	{
		var c = Assemblies
			.SelectMany(
				assembly => assembly.GetTypes(),
				// ReSharper disable once UnusedParameter.Local
				(assembly, type) => new
				{
					Type = type,
					PuzzleAttribute = type.GetCustomAttribute<PuzzleAttribute>()!,
				})
			.Where(x => x.PuzzleAttribute != null);

		return c
			.Select(x => new PuzzleModel(
				x.PuzzleAttribute.Name,
				x.PuzzleAttribute.Year,
				x.PuzzleAttribute.Day,
				x.PuzzleAttribute.CodeType,
				x.Type))
			.ToList();
	}

	private static PuzzleResult RunPuzzle<TPuzzle>(PuzzleModel puzzleInfo)
		where TPuzzle : IPuzzle, new()
	{
		var puzzle = new TPuzzle();

		var rawInput = PuzzleInputProvider.Instance
			.GetRawInput(puzzleInfo.Year, puzzleInfo.Day);

		var sw = Stopwatch.StartNew();
		var (part1, part2) = puzzle.Solve(rawInput);
		sw.Stop();
		var elapsed = sw.Elapsed;

		// run twice to get better timings
		if (elapsed < TimeSpan.FromMilliseconds(500))
		{
			sw.Restart();
			puzzle.Solve(rawInput);
			sw.Stop();
			elapsed = sw.Elapsed;
		}

		return new PuzzleResult(puzzleInfo, part1, part2, elapsed);
	}
}
