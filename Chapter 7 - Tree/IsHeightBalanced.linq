<Query Kind="Program" />

void Main()
{
	var node = new TreeNode(1);
	node.left = new TreeNode(9);
	node.right = new TreeNode(8);

	node.left.left = new TreeNode(10);
	node.left.right = new TreeNode(11);

	IsBalanced(node).Dump();
	MinDepth(node).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public bool IsBalanced(TreeNode root)
{
	if(Height(root) == int.MaxValue)
	{
		return false;
	}
	
	return true;
}

public int Height(TreeNode root)
{
	if(root == null)
	{
		return 0;
	}

	var left = Height(root.left);
	if (left == int.MaxValue)
	{
		return int.MaxValue;
	}
	
	var right = Height(root.right);
	
	if(left ==  int.MaxValue)
	{
		return int.MaxValue;
	}
	
	if(Math.Abs(left-right) > 1)
	{
		return int.MaxValue;
	}
	
	return 1 + Math.Max(left, right);
}


public int MinDepth(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}

	var left = MinDepth(root.left);
	var right = MinDepth(root.right);
	
	if(right == 0)
	{
		return 1 + left;
	}

	if (left == 0)
	{
		return 1 + right;
	}
	
	return 1 + Math.Min(left, right);
}
