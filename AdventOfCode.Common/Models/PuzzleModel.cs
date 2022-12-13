using AdventOfCodeCommon.Attributes;

namespace AdventOfCodeCommon.Models;

public readonly record struct PuzzleModel(
	string? Name,
	int Year,
	int Day,
	CodeType CodeType,
	Type PuzzleType);
