using AdventOfCode2022.Challenges.Day02;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day02;

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
            "A X",
            "A Y",
            "A Z",
            "B X",
            "B Y",
            "B Z",
            "C X",
            "C Y",
            "C Z"
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("45");
    }

    [Fact]
    public void Calculate_ShouldReturnArgumentExceptionWhenInputInvalid()
    {
        // Arrange
        var input = new[]
        {
            "P P"
        };

        // Act
        Action result = () => _sut.Calculate(input);

        // Assert
        result.Should().Throw<ArgumentException>().WithMessage("Invalid input");
    }
}