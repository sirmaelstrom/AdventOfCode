using AdventOfCode2022.Challenges.Day08;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day08;

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
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("21");
    }
}