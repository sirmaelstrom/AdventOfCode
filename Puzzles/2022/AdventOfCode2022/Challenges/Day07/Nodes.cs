namespace AdventOfCode2022.Challenges.Day07;

public abstract class Node
{
    public FolderNode? Parent;
    public string Name = null!;

    public abstract long GetSize();
}

public class FileNode : Node
{
    public int Size;

    public override long GetSize()
    {
        return Size;
    }
}

public class FolderNode : Node
{
    public List<Node> Contents { get; } = new();

    public override long GetSize()
    {
        return Contents.Sum(n => n.GetSize());
    }
    
    public List<FolderNode> GetSubFolders()
    {
        return Contents.OfType<FolderNode>().ToList();
    }
}