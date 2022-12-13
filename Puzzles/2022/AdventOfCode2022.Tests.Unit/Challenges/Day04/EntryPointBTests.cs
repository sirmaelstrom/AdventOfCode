using AdventOfCode2022.Challenges.Day04;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day04;

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
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8"
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("4");
    }
    
    [Fact]
    public void Calculate_ShouldThrowFormatExceptionWhenInputInvalid()
    {
        // Arrange
        var input = new[]
        {
            "2-4,6-"
        };

        // Act
        Action result = () => _sut.Calculate(input);

        // Assert
        result.Should().Throw<FormatException>();
    }
    
    [Fact]
    public void Calculate_ShouldThrowArgumentExceptionWhenInputInvalid()
    {
        // Arrange
        var input = new[]
        {
            "2-4,6-8,7-9"
        };

        // Act
        Action result = () => _sut.Calculate(input);

        // Assert
        result.Should().Throw<ArgumentException>().WithMessage("Invalid input");
    }
}