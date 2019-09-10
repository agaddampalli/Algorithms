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

	PathSum(root, 8).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

//https://leetcode.com/problems/path-sum-iii/

public int PathSum(TreeNode root, int sum)
{
	int res = pathSumHelper(root, sum);
	if (root != null)
	{
		res += PathSum(root.left, sum) + PathSum(root.right, sum);
	}
	return res;
}

public int pathSumHelper(TreeNode root, int sum)
{
	if (root == null) return 0;
	int res = root.val == sum ? 1 : 0;
	return res + pathSumHelper(root.left, sum - root.val) + pathSumHelper(root.right, sum - root.val);
}