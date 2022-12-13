using AdventOfCode2022.Challenges.D12;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day12;

public class EntryPointATests
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
        /*  "Sabqponm"
            "abcryxxl",
            "accszExk",
            "acctuvwj",
            "abdefghi"
         */
        var input = new[]
        {
            Convert.ToByte('S'), Convert.ToByte('a'), Convert.ToByte('b'), Convert.ToByte('q'), Convert.ToByte('p'),
            Convert.ToByte('o'), Convert.ToByte('n'), Convert.ToByte('m'), Convert.ToByte('\n'),
            Convert.ToByte('a'), Convert.ToByte('b'), Convert.ToByte('c'), Convert.ToByte('r'), Convert.ToByte('y'),
            Convert.ToByte('x'), Convert.ToByte('x'), Convert.ToByte('l'), Convert.ToByte('\n'),
            Convert.ToByte('a'), Convert.ToByte('c'), Convert.ToByte('c'), Convert.ToByte('s'), Convert.ToByte('z'),
            Convert.ToByte('E'), Convert.ToByte('x'), Convert.ToByte('k'), Convert.ToByte('\n'),
            Convert.ToByte('a'), Convert.ToByte('c'), Convert.ToByte('c'), Convert.ToByte('t'), Convert.ToByte('u'),
            Convert.ToByte('v'), Convert.ToByte('w'), Convert.ToByte('j'), Convert.ToByte('\n'),
            Convert.ToByte('a'), Convert.ToByte('b'), Convert.ToByte('d'), Convert.ToByte('e'), Convert.ToByte('f'),
            Convert.ToByte('g'), Convert.ToByte('h'), Convert.ToByte('i'), Convert.ToByte('\n')
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("31");
    }
}