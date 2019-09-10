<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(5);
	root.left = new TreeNode(4);
	root.right = new TreeNode(5);
	root.left.right = new TreeNode(1);
	root.left.left = new TreeNode(1);

	root.right.left = new TreeNode(5);

	LongestUnivaluePath(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}


public int max = 0;
public int LongestUnivaluePath(TreeNode root)
{
	Longest(root);
	
	return max;
}


public int Longest(TreeNode root)
{
	if(root == null)
	{
		return 0;
	}

	var left = Longest(root.left);
	var right = Longest(root.right);
	
	var leftCount = 0;
	if(root.left != null && root.left.val == root.val)
	{
		leftCount = 1 + left;
	}

	var rightCount = 0;
	if (root.right != null && root.right.val == root.val)
	{
		rightCount = 1 + right;
	}
	
	max = Math.Max(max, leftCount + rightCount);
	return Math.Max(leftCount,rightCount);
}