using AdventOfCode2022.Challenges.Day05;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day05;

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
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("MCD");
    }
}