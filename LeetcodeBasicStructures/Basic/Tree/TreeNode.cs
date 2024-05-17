namespace LeetcodeBasicStructures.Basic.Tree;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }

    /// <summary>
    /// Creates new tree from preorder-traversal array
    /// </summary>
    /// <param name="array">Preorder-traversal array</param>
    /// <returns>Root of the new tree</returns>
    /// <exception cref="ArgumentException">Array is empty or tree root is null</exception>
    public static TreeNode FromArray(int?[] array)
    {
        if (array.Length == 0) throw new ArgumentException("array was empty", nameof(array));
        if (array[0] is null) throw new ArgumentException("tree root is null", nameof(array));
        var treeNodes = new TreeNode?[array.Length];

        for (var i = 0; i < array.Length; i++)
        {
            if (!array[i].HasValue)
            {
                treeNodes[i] = null;
                continue;
            }

            treeNodes[i] = new TreeNode(array[i]!.Value);
        }

        for (var i = 0; i < treeNodes.Length; i++)
        {
            if (treeNodes[i] is null) continue;
            
            var left = i * 2 + 1;
            var right = i * 2 + 2;

            if (left < treeNodes.Length) treeNodes[i]!.left = treeNodes[left];
            if (right < treeNodes.Length) treeNodes[i]!.right = treeNodes[right];
        }

        return treeNodes[0]!;
    }
}
