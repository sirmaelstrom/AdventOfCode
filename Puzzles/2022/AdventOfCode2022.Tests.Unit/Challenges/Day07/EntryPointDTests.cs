using AdventOfCode2022.Challenges.Day07;
using AdventOfCodeCommon.Interfaces;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests.Unit.Challenges.Day07;

public class EntryPointDTests : IEntryPointTest
{
    private readonly EntryPointD _sut;

    public EntryPointDTests()
    {
        _sut = new EntryPointD();
    }
    
    [Fact]
    public void Calculate_ShouldReturnResultFromChallengerDescription()
    {
        // Arrange
        var input = new[]
        {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
        };

        // Act
        var result = _sut.Calculate(input);

        // Assert
        result.Should().Be("Part 1: 95437\nPart 2: 24933642");
    }
}