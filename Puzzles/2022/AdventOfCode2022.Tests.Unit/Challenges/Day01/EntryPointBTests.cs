using AdventOfCode2022.Challenges.D01;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day01;

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
            "8669",
            "",
            "2790",
            "1196",
            "3619",
            "1692",
            "8727",
            "2342",
            "1099",
            "6083",
            "3834",
            "2008",
            "",
            "1"
            
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("123932");
    }
}