<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	root.left.left = new TreeNode(2);
	root.left.right = new TreeNode(2);
	root.right.right = new TreeNode(3);

	
	CountUnivalSubtrees(root).Dump();
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public int CountUnivalSubtrees(TreeNode root)
{
	var count = new int[1];
	countUnivalSubtrees(root, count);
	return count[0];
}

private bool countUnivalSubtrees(TreeNode root, int[] count)
{
	if (root == null)
	{
		return true;
	}

	var left = countUnivalSubtrees(root.left, count);
	var right = countUnivalSubtrees(root.right, count);

	if (left && right)
	{
		if (root.left != null && root.val != root.left.val)
		{
			return false;
		}
		if (root.right != null && root.val != root.right.val)
		{
			return false;
		}
		count[0]++;
		return true;
	}
	return false;
}