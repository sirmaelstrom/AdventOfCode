using AdventOfCode.Runner;
using AdventOfCode2022.Challenges.D13;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day13;

public class Day13OriginalTest : IEntryPointTest
{
    private readonly Day13Original _sut;
    
    public Day13OriginalTest()
    {
        _sut = new Day13Original();
    }
    
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        var puzzleInput = BenchmarkInputProvider.GetRawInput(2022, 13, "test_");

        // Act
        var result = _sut.Solve(puzzleInput);

        // Assert
        result.Should().Be(("13", "140"));
    }
}