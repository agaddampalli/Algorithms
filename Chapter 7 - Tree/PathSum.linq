<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(5);
	root.right.right = new TreeNode(6);

	HasPathSum(root, 1).Dump();
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public bool HasPathSum(TreeNode root, int sum)
{
	if (root == null)
	{
		return false;
	}
	
	if (root.right == null && root.left == null && sum == root.val)
	{
		return true;
	}
	
	return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
}