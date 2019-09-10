<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(2);

	root.left.left = new TreeNode(5);
	root.left.right = new TreeNode(7);
	
	root.right.right = new TreeNode(5);
	root.right.left = new TreeNode(7);
	
	IsSymmetric(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public bool IsSymmetric(TreeNode root)
{
	if(root == null)
	{
		return true;
	}
	
	return IsSymmetric(root.left, root.right);
}

public bool IsSymmetric(TreeNode left, TreeNode right)
{
	if(left == null && right == null)
	{
		return true;
	}

	if (left == null || right == null)
	{
		return false;
	}
	
	if(left.val != right.val)
	{
		return false;
	}
	
	return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
}