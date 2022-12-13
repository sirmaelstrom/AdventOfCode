using AdventOfCode2022.Challenges.Day06;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day06;

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
            "mjqjpqmgbljsphdztnvjfqwrcgsmlb"
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("7");
    }

    [Theory]
    [InlineData(new[] { "bvwbjplbgvbhsrlpgdmjqwftvncz" }, "5")]
    [InlineData(new[] { "nppdvjthqldpwncqszvftbrmjlhg" }, "6")]
    [InlineData(new[] { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" }, "10")]
    [InlineData(new[] { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" }, "11")]
    [InlineData(new[] { "zcfzfwzzqf" }, "Not found")]
    public void Calculate_ShouldReturnResultFromChallengerDescriptionExtended(string[] input, string expected)
    {
        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be(expected);
    }
}