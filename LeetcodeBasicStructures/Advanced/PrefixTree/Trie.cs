namespace LeetcodeBasicStructures.Advanced.PrefixTree;

/// <summary>
/// Simple implementation of Trie data structure (https://en.wikipedia.org/wiki/Trie)
/// </summary>
public class Trie
{
    private TrieNode _root = new TrieNode(false);

    /// <summary>
    /// Insert new word to trie
    /// </summary>
    /// <param name="word">The word to insert</param>
    public void Insert(string word)
    {
        var currentNode = _root;
        var count = 0;
        foreach (var c in word)
        {
            if (currentNode.HasChild(c))
            {
                currentNode = currentNode.GetChild(c);
                count++;
            }
            else break;
        }

        for (var i = count; i < word.Length; i++)
        {
            var newNode = currentNode.AddChild(word[i], i == word.Length - 1);
            currentNode = newNode;
        }

        if (count == word.Length)
        {
            currentNode.IsTerminal = true;
        }
    }

    /// <summary>
    /// Search the word in this trie
    /// </summary>
    /// <param name="word">The word to look for</param>
    /// <returns>Is the word presented in this trie</returns>
    public bool Search(string word)
    {
        var node = SearchForPrefixNode(word);
        if (node is null) return false;
        return node.IsTerminal;
    }

    /// <summary>
    /// Check if the prefix is in the trie
    /// </summary>
    /// <param name="prefix">The prefix to look for</param>
    /// <returns>Is the prefix presented in this trie</returns>
    public bool StartsWith(string prefix)
    {
        return SearchForPrefixNode(prefix) is not null;
    }

    /// <summary>
    /// Delete word from trie, possibly altering its structure.
    /// If the word is not found in this trie this method does nothing
    /// </summary>
    /// <param name="word">The word to delete</param>
    public void Delete(string word)
    {
        var currentNode = _root;
        var lastJunction = _root;
        var lastJunctionIndex = -1;
        for (var i = 0; i < word.Length; i++)
        {
            currentNode = currentNode.GetChild(word[i]);
            if (currentNode.ChildrenCount() > 1)
            {
                lastJunction = currentNode;
                lastJunctionIndex = i;
            }
        }

        if (currentNode.IsTerminal)
            currentNode.IsTerminal = false;

        if (currentNode.ChildrenCount() == 0 && lastJunctionIndex + 1 < word.Length)
            lastJunction.DeleteChild(word[lastJunctionIndex + 1]);
    }

    private TrieNode SearchForPrefixNode(string prefix)
    {
        var currentNode = _root;
        foreach (var c in prefix)
        {
            if (!currentNode.HasChild(c)) return null;
            currentNode = currentNode.GetChild(c);
        }

        return currentNode;
    }
}
