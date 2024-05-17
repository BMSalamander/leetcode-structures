namespace LeetcodeBasicStructures.Basic.LinkedList;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
    
    /// <summary>
    /// Prints single-linked list and flushes the stream after writing
    /// </summary>
    /// <param name="stream">Stream for writing to (defaults to Console.Out)</param>
    public void Print(TextWriter? stream = null)
    {
        var writer = stream ?? Console.Out;
        writer.Write('[');
        var current = this;
        while (current.next is not null)
        {
            writer.Write($"{current.val}, ");
            current = current.next;
        }
        writer.Write($"{current.val}]");
        writer.Flush();
    }

    /// <summary>
    /// Create new single-linked list from enumerable of ints
    /// </summary>
    /// <param name="ints">Numbers</param>
    /// <returns>Single-lingked list</returns>
    /// <exception cref="ArgumentException">ints is empty</exception>
    public static ListNode FromEnumberable(IEnumerable<int> ints)
    {
        var enumerable = ints as int[] ?? ints.ToArray();
        if (enumerable.Length == 0) throw new ArgumentException("enumerable is empty", nameof(ints));

        var head = new ListNode(enumerable[0]);
        var current = head;
        foreach (var num in enumerable.Skip(1))
        {
            var node = new ListNode(num);
            current.next = node;
            current = node;
        }
        return head;
    }
}
