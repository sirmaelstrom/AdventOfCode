using AdventOfCode2022.Challenges.D01;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day01;

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
            "2991",
            "13880",
            "13279",
            "1514",
            "9507",
            "",
            "6544",
            "9672",
            "13044",
            "4794",
            "6648",
            "8669"
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("49371");
    }
}