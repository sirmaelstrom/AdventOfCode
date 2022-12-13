using AdventOfCode2022.Challenges.Day06;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day06;

public class EntryPointBTests : IEntryPointTest
{
    private readonly EntryPointB _sut;

    public EntryPointBTests()
    {
        _sut = new EntryPointB();
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
        result.Should().Be("19");
    }

    [Theory]
    [InlineData(new[] { "bvwbjplbgvbhsrlpgdmjqwftvncz" }, "23")]
    [InlineData(new[] { "nppdvjthqldpwncqszvftbrmjlhg" }, "23")]
    [InlineData(new[] { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" }, "29")]
    [InlineData(new[] { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" }, "26")]
    [InlineData(new[] { "zzqfzfzzfwzzqf" }, "Not found")]
    public void Calculate_ShouldReturnResultFromChallengerDescriptionExtended(string[] input, string expected)
    {
        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be(expected);
    }
}