using AdventOfCode2022.Challenges.Day03;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day03;

public class EntryPointATests : IEntryPointTest
{
    private readonly EntryPointA _sut;

    public EntryPointATests()
    {
        _sut = new EntryPointA();
    }
    
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "vJrwpWtwJgWrhcsFMMfFFhFp", // 16 (p)
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", //38 (L)
            "PmmdzqPrVvPwwTWBwg", // 42 (P)
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", // 22 (v)
            "ttgJtRGJQctTZtZT", // 20 (t)
            "CrZsJsPPZsGzwwsLwLmpwMDw" // 19 (s)
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("157");
    }
}