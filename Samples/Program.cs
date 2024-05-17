using LeetcodeBasicStructures.Basic.LinkedList;
using LeetcodeBasicStructures.Basic.Tree;

int[] intsForList = [1, 2, 3, 4, 5]; // Create array of ints, copy this from LC problem description
var newList = ListNode.FromEnumberable(intsForList); // Call this function to create new single-linked list from given array

newList.Print(); // Prints your list to console

using (var fileStream = File.OpenWrite("test")) // You also can print list using any available text writer
using (var writer = new StreamWriter(fileStream)) // For example you can create writer from file stream
{
    newList.Print(writer); 
}

int?[] intsForTree = [2,1,3,null,null,0,1]; // Create array of nullable ints (which is preorder traversed tree values with leafs), copy this from LC problem description
var newTree = TreeNode.FromArray(intsForTree); // Call this function to create new binary tree from given array