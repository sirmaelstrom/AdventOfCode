using AdventOfCode2021.Challenges.D02;
using AdventOfCode2021.Tests.Unit.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021.Tests.Unit.Challenges.D02;

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
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2",
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("900");
    }
    
    [Fact]
    public void Calculate_ShouldReturnArgumentExceptionWhenInputInvalid()
    {
        var input = new[]
        {
            "forward P"
        };

        // Act
        Action result = () => _sut.Calculate(input);

        // Assert
        result.Should().Throw<ArgumentException>().WithMessage("Invalid input");
    }
}