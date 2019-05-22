<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(2);
	root.left = new TreeNode(-1);
	root.right = new TreeNode(-3);
//
//	root.left.left = new TreeNode(1);
//	root.left.right = new TreeNode(3);
//	root.right.left = new TreeNode(-2);
////	root.right.right = new TreeNode(7);
//
//
//	root.left.left.left = new TreeNode(-1);
//	root.left.left.right = new TreeNode(1);

	MaxPathSum(root).Dump();
	maxvalue.Dump();

}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public int maxvalue = int.MinValue;

public int MaxPathSum(TreeNode root)
{
	MaxSum(root);
	
	return maxvalue;
}

private int MaxSum(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}
	
	var lSum = Math.Max(0, MaxSum(root.left));
	var rSum = Math.Max(0, MaxSum(root.right));

	maxvalue = Math.Max(maxvalue, lSum + rSum + root.val);

	return Math.Max(lSum, rSum) + root.val;;
}