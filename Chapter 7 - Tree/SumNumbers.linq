<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(0);
	root.left = new TreeNode(1);
//	root.right = new TreeNode(3);
//
//
//	root.left.left = new TreeNode(4);
//	root.left.right = new TreeNode(5);

	SumNumbers(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public int SumNumbers(TreeNode root)
{
	return SumNumbers(root, 0);
}

public int SumNumbers(TreeNode root, int sum)
{
	if (root == null)
	{
		return 0;
	}
	
	if(root.left == null && root.right == null)
	{
		return sum * 10 + root.val;
	}
	
	var left = SumNumbers(root.left , root.val + sum * 10);
	var right = SumNumbers(root.right , root.val + sum * 10);
	return left + right;
}