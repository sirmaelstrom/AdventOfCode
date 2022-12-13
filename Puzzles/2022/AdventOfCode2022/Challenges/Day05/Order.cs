namespace AdventOfCode2022.Challenges.Day05;

internal readonly struct Order
{
    private readonly int _count;
    private readonly int _from;
    private readonly int _to;

    public Order(string count, string from, string to)
    {
        _count = int.Parse(count);
        _from = int.Parse(from) - 1;
        _to = int.Parse(to) - 1;
    }

    public void MoveBoxes(List<Stack<char>> stacks, bool reverse = false)
    {
        var boxes = new List<char>();
        for (var i = 0; i < _count; i++)
        {
            boxes.Add(stacks[_from].Pop());
        }

        if(reverse)
            boxes.Reverse();
        
        foreach (var box in boxes)
        {
            stacks[_to].Push(box);
        }
    }
}