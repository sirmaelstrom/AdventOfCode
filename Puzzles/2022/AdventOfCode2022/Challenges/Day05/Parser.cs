namespace AdventOfCode2022.Challenges.Day05;
internal static class ParserExtensions
{
    internal static List<Stack<char>> ConvertStackDrawingToStacks(this IReadOnlyList<string> input)
    {
        var rows = input.SkipLast(1).ToArray();
        var columnCount = int.Parse(input[^1].TrimEnd().Last().ToString());

        var stacks = new List<Stack<char>>();
        for (var i = 0; i < columnCount; i++)
        {
            stacks.Add(new Stack<char>());
        }

        for (var i = 0; i < columnCount; i++)
        {
            var columnValues = rows.Select(column => column[i * 4 + 1]).Reverse().ToArray();
            foreach (var c in columnValues)
            {
                if (c != ' ') stacks[i].Push(c);
            }
        }

        return stacks;
    }
    
    internal static string[] ExtractStackDrawing(this IEnumerable<string> input)
    {
        return input.TakeWhile(x => x != "").ToArray();
    }
    
    internal static IEnumerable<Order> GenerateOrdersEnumerable(this IEnumerable<string> input)
    {
        var orders = input
            .SkipWhile(x => x != "")
            .Skip(1)
            .Select(x => x.Split(' '))
            .Select(x => new Order(x[1], x[3], x[5]));
        return orders;
    }
}