namespace AdventOfCode2022.Challenges.Day06;

internal static class Parser
{
    private static bool IsUnique(string input)
    {
        var count = new int[256];
        Array.Clear(count, 0, count.Length - 1);
        return input.All(c => ++count[c] <= 1);
    }

    internal static string Solve(this string[] input, int bufferSize)
    {
        for (var i = 0; i <= input[0].Length - bufferSize; i++)
        {
            if (!IsUnique(input[0].Substring(i, bufferSize))) 
                continue;
        
            return (i + bufferSize).ToString();
        }
        
        return "Not found";
    }

    /// <summary>
    /// Alternative implementation using queue
    /// </summary>
    /// <param name="input"></param>
    /// <param name="bufferSize"></param>
    /// <returns></returns>
    internal static string SolveQueue(this string[] input, int bufferSize)
    {
        var queue = new Queue<char>();

        var inputAsSpan = input[0].AsSpan();
        foreach (var c in inputAsSpan[..bufferSize])
        {
            queue.Enqueue(c);
        }

        for (var j = bufferSize; j < input[0].Length; j++)
        {
            if (queue.Distinct().Count() == bufferSize)
            {
                return j.ToString();
            }
            
            queue.Dequeue();
            queue.Enqueue(inputAsSpan[j]);
        }

        return "Not found";
    }
}