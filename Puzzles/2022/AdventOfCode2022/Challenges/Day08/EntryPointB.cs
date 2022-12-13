using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day08;

public class EntryPointB : IEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public string Calculate(string[] input)
    {
        var scenicScores = new List<int>();
        for (var i = 0; i < input.Length; i++)
        {
            for (var j = 0; j < input[i].Length; j++)
            {
                var left = CountScenicScore(j, i, -1, 0, input[i][j]);
                var right = CountScenicScore(j, i, 1, 0, input[i][j]);
                var up = CountScenicScore(j, i, 0, -1, input[i][j]);
                var down = CountScenicScore(j, i, 0, 1, input[i][j]);
                scenicScores.Add(left * right * up * down);
            }
        }
       
        int CountScenicScore(int x, int y, int xd, int yd, char startValue)
        {
            if (x == 0 || x == input.Length - 1 || y == 0 || y == input.Length - 1)
                return 0;
            if (startValue <= input[y + yd][x + xd])
                return 1 ;

            return 1 + CountScenicScore(x + xd,y + yd,xd, yd, startValue);
        }

        return scenicScores.Max().ToString();
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day08/input.txt"));
}