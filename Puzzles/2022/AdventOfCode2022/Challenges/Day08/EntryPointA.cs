using AdventOfCodeCommon.Interfaces;

namespace AdventOfCode2022.Challenges.Day08;

public class EntryPointA : IEntryPoint
{
    public void Run()
    {
        var input = ReadFile();
        var result = Calculate(input);
        Console.WriteLine(result);
    }

    public string Calculate(string[] input)
    {
        var visible = 0;
        for(var i=0; i<input.Length; i++)
        {
            for(var j=0; j < input[i].Length;j++)
            {
                var left = CountVisible(j, i, -1, 0, input[i][j]);
                var right= CountVisible(j, i, 1, 0, input[i][j]);
                var up = CountVisible(j, i, 0, -1, input[i][j]);
                var down= CountVisible(j, i, 0, 1, input[i][j]);
                if (up || down || left || right)
                    visible++;
            }
        }
        
        bool CountVisible(int x, int y, int xd, int yd, char startValue)
        {
            if (x == 0 || x == input.Length - 1 || y == 0 || y == input.Length - 1)
                return true;
            return startValue > input[y + yd][x + xd] && CountVisible(x + xd, y + yd, xd, yd, startValue);
        }

        return visible.ToString();
    }

    public string[] ReadFile() => File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "../../../Challenges/Day08/input.txt"));
}