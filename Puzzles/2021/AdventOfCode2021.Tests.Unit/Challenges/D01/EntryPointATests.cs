using AdventOfCode2021.Challenges.D01;
using AdventOfCode2021.Tests.Unit.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021.Tests.Unit.Challenges.D01;

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
            "199",
            "200",
            "208",
            "210",
            "200",
            "207",
            "240",
            "269",
            "260",
            "263"
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("7");
    }

    [Fact]
    public void Calculatte_ShouldThrowArgumentExceptionWhenInputInvalid()
    {
        // Arrange
        var input = new[]
        {
            "PP"
        };

        // Act
        Action result = () => _sut.Calculate(input);

        // Assert
        result.Should().Throw<ArgumentException>().WithMessage("Invalid input");
    }
}