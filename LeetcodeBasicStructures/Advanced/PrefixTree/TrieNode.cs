namespace LeetcodeBasicStructures.Advanced.PrefixTree;

internal class TrieNode(bool isTerminal)
{
    private readonly Dictionary<char, TrieNode> _children = new();
    public bool IsTerminal { get; set; } = isTerminal;

    public TrieNode? AddChild(char value, bool isTerminal = false)
    {
        var newNode = new TrieNode(isTerminal);
        return _children.TryAdd(value, newNode) ? newNode : null;
    }

    public bool HasChild(char value) => _children.ContainsKey(value);
    public TrieNode GetChild(char value) => _children[value];

    public void DeleteChild(char value) => _children.Remove(value);

    public int ChildrenCount() => _children.Count;
}
