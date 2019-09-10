<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);

	root.left = new TreeNode(5);
	root.right = new TreeNode(-3);

	root.left.left = new TreeNode(3);
	root.left.right = new TreeNode(2);

	root.left.left.left = new TreeNode(3);
	root.left.left.right = new TreeNode(-2);

	root.left.right.right = new TreeNode(1);

	root.right.right = new TreeNode(11);

	GetSumTreeNode(root, 8).Dump();
}

public class TreeNode
{
	public int val {get; set;}
	public TreeNode left {get; set;}
	public TreeNode right {get; set;}
	
	public TreeNode(int val)
	{
		this.val = val;
	}
}

TreeNode output;
public TreeNode GetSumTreeNode(TreeNode root, int target)
{
	DFS(root, target);
	
	return output;
}

public int DFS(TreeNode root, int target)
{
	if(root == null)
	{
		return 0;
	}
	
	if(root.left == null && root.right == null)
	{
		return root.val;
	}
	
	var left = DFS(root.left, target);
	
	if(left == int.MaxValue)
	{
		return left;
	}

	var right = DFS(root.right, target);

	if (right == int.MaxValue)
	{
		return right;
	}
	
	if(root.val + left + right == target)
	{
		output = root;
		return int.MaxValue;
	}
	
	return left + right;
}