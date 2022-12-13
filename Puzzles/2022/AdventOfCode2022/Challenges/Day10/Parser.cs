using AdventOfCodeCommon;

namespace AdventOfCode2022.Challenges.Day10;

public static class Parser
{
    public static string DrawScreen(IEnumerable<string> instructions)
    {
        var c = 0;
        var x = 1;
        
        var screen = new[]
        {
            new char[40],
            new char[40],
            new char[40],
            new char[40],
            new char[40],
            new char[40],
        };
        using var e = instructions.GetEnumerator();
        e.MoveNext();
        var inAdd = false;
        for (c = 0, x = 1; c < 240; c++)
        {
            var character = Math.Abs((c % 40) - x) <= 1 ? '#' : '.';
            screen[c / 40][c % 40] = character;

            if (e.Current == "noop")
                e.MoveNext();
            else if (!inAdd)
                inAdd = true;
            else
            {
                inAdd = false;
                x += int.Parse(e.Current[5..]);
                e.MoveNext();
            }
        }

        return string.Join(Environment.NewLine,
            screen.Select(l => string.Join("", l)));
    }

    public static string CalculateSignalStrength(IEnumerable<string> instructions)
    {
        var c = 0;
        var x = 1;
        var s = 0;

        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case "noop":
                    c++;
                    if (c % 40 == 20) { s += c * x; }
                    break;
                default:
                    c += 2;
                    switch (c % 40)
                    {
                        case 20:
                            s += c * x;
                            break;
                        case 21:
                            s += x * (c - 1);
                            break;
                    }
                    
                    var (amt, _) = instruction.AsSpan()[5..].AtoI();
                    x += amt;
                    break;
            }
            
            if (c > 220) break;
        }
        
        return s.ToString();
    }
    
}