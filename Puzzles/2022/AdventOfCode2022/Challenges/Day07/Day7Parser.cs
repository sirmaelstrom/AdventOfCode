using AdventOfCodeCommon;
using System.Diagnostics;

namespace AdventOfCode2022.Challenges.Day07;

internal static class Day7Parser
{
    internal static Dictionary<string, MyFolder> GenerateDirectoryDictionaryTree(string[] input)
    {
        var tree = new Dictionary<string, MyFolder>
        {
            { "/", new MyFolder("/") }
        };

        var currentDir = tree["/"];
        for (var i = 0; i < input.Length; i++)
        {
            var line = input[i];
            if (line.StartsWith("$ cd "))
            {
                var nextDirName = line[5..];
                Debug.Assert(currentDir != null, nameof(currentDir) + " != null");
                currentDir = nextDirName switch
                {
                    "/" => tree["/"],
                    ".." => currentDir.Parent,
                    _ => currentDir.Children.First(x => x.Name == nextDirName)
                };
            }
            else if (line.StartsWith("$ ls"))
            {
                var args = input.Skip(i + 1)
                    .TakeWhile(x => !x.StartsWith("$"))
                    .ToArray();

                foreach (var arg in args)
                {
                    if (arg.StartsWith("dir "))
                    {
                        var dirName = arg[4..];
                        var dir = new MyFolder(dirName)
                        {
                            Parent = currentDir
                        };
                        var path = GetPath(dir);
                        tree.TryAdd(path, dir);
                        currentDir!.Children.Add(dir);
                    }
                    else
                    {
                        var file = arg.Split(" ");
                        Debug.Assert(currentDir != null, nameof(currentDir) + " != null");
                        currentDir.Files.Add(new MyFile(file[1], int.Parse(file[0])));
                    }
                }
                
                i += args.Length;
            }
        }
        
        return tree;
    }
    
    internal static void GenerateDirectoryNodes(string[] input, FolderNode? root)
    {
        var cwd = root;

        foreach (var arg in input.AsSpan())
        {
            if (arg == "$ cd ..")
            {
                Debug.Assert(cwd != null, nameof(cwd) + " != null");
                cwd = cwd.Parent;
            }
            else if (arg.StartsWith("$ cd "))
            {
                Debug.Assert(cwd != null, nameof(cwd) + " != null");
                foreach (var n in cwd.Contents.Where(n => n.Name == arg[5..]))
                {
                    cwd = (FolderNode)n;
                    break;
                }
            }
            else if (arg.StartsWith("dir"))
            {
                var folder = new FolderNode
                {
                    Name = arg[4..],
                    Parent = cwd
                };
                Debug.Assert(cwd != null, nameof(cwd) + " != null");
                cwd.Contents.Add(folder);
            }
            else if (!arg.StartsWith("$ ls"))
            {
                var file = new FileNode
                {
                    Name = arg.Split()[1],
                    Size = int.Parse(arg.Split()[0]),
                    Parent = cwd
                };
                Debug.Assert(cwd != null, nameof(cwd) + " != null");
                cwd.Contents.Add(file);
            }
        }
    }
    
    internal static Dictionary<string, Dictionary<string, int>> GenerateDirectorySizeDictionary(string[] input)
    {
        var cwd = string.Empty;
        var dirs = new Dictionary<string, Dictionary<string, int>>();

        foreach (var l in input.AsSpan())
        {
            if (l.Equals("$ cd .."))
            {
                var previousSlash = cwd.LastIndexOf('/', cwd.Length - 2) + 1;
                var name = cwd[previousSlash..^1];
                var parent = cwd[..previousSlash];

                dirs[parent][name] = dirs[cwd].Values.Sum();

                cwd = parent;
            }
            else if (l.StartsWith("$ cd "))
            {
                var path = l[5..];
                cwd = path.StartsWith("/") ? path : $"{cwd}{path}/";
            }
            else if (l.StartsWith("dir"))
            {
                dirs.GetOrAdd(cwd, _ => new())[l[4..]] = 0;
            }
            else if (!l.StartsWith("$ ls"))
            {
                var size = int.Parse(l.Split()[0]);
                var name = l.Split()[1];

                dirs.GetOrAdd(cwd, _ => new())[name] = size;
            }
        }

        while (cwd != "/")
        {
            var previousSlash = cwd.LastIndexOf('/', cwd.Length - 2) + 1;
            var name = cwd[previousSlash..^1];
            var parent = cwd[..previousSlash];

            dirs[parent][name] = dirs[cwd].Values.Sum();

            cwd = parent;
        }

        return dirs;
    }

    private static string GetPath(MyFolder folder)
    {
        var path = new List<string>();
        while (folder.Parent is not null)
        {
            path.Add(folder.Name);
            folder = folder.Parent;
        }

        path.Reverse();
        return string.Join("/", path);
    }

}