using SuperLinq;

namespace AdventOfCode2022.Challenges.D11;

public static class Parser
{
	internal static readonly Func<long, long>[] Operations =
	{
		i => i * 5,
		i => i + 3,
		i => i + 7,
		i => i + 5,
		i => i + 2,
		i => i * 19,
		i => i * i,
		i => i + 4,
	};

	private static List<Monkey> ParseInput(IEnumerable<string> input, IReadOnlyList<Func<long, long>> operations)
	{
		return input.Split(string.Empty)
			.Select(m =>
			{
				var enumerable = m as string[] ?? m.ToArray();
				var id = int.Parse(enumerable.First()[7..].Replace(":", ""));
				var items = enumerable.ElementAt(1)[18..]
					.Split(", ")
					.Select(long.Parse)
					.ToList();
				var operation = operations[id];
				var test = int.Parse(enumerable.ElementAt(3)[21..]);
				var ifTrue = int.Parse(enumerable.ElementAt(4)[29..]);
				var ifFalse = int.Parse(enumerable.ElementAt(5)[30..]);

				return new Monkey
				{
					Items = items,
					Operation = operation,
					Test = test,
					IfTrue = ifTrue,
					IfFalse = ifFalse,
				};
			})
			.ToList();
	}

	internal static string CalculatePart1(IEnumerable<string> input, IReadOnlyList<Func<long, long>> operations)
	{
		var monkeys = ParseInput(input, operations);
		
		for (var i = 0; i < 20; i++)
		{
			foreach (var m in monkeys)
			{
				foreach (var item in m.Items)
				{
					var v = m.Operation(item) / 3;
					var next = v % m.Test == 0 ? m.IfTrue : m.IfFalse;
					monkeys[next].Items.Add(v);
				}

				m.Activity += m.Items.Count;
				m.Items.Clear();
			}
		}

		var top2 = monkeys
			.Select(m => m.Activity)
			.PartialSort(2, OrderByDirection.Descending)
			.ToList();
		
		return (top2[0] * top2[1]).ToString();
	}

	internal static string CalculatePart2(IEnumerable<string> input, IReadOnlyList<Func<long, long>> operations)
	{
		var monkeys = ParseInput(input, operations);
		
		var factor = monkeys.Aggregate(1L, (f, m) => f * m.Test);
		for (var i = 0; i < 10_000; i++)
		{
			foreach (var m in monkeys)
			{
				foreach (var item in m.Items)
				{
					var v = m.Operation(item) % factor;
					var next = v % m.Test == 0 ? m.IfTrue : m.IfFalse;
					monkeys[next].Items.Add(v);
				}

				m.Activity += m.Items.Count;
				m.Items.Clear();
			}
		}

		var top2 = monkeys.Select(m => m.Activity)
			.PartialSort(2, OrderByDirection.Descending)
			.ToList();
		return (top2[0] * top2[1]).ToString();
	}
}

internal class Monkey
{
	public required List<long> Items { get; init; }
	public required Func<long, long> Operation { get; init; }
	public required int Test { get; init; }
	public required int IfTrue { get; init; }
	public required int IfFalse { get; init; }
	public long Activity { get; set; }
}