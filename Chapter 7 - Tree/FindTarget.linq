<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(5);
	root.left = new TreeNode(3);
	root.right = new TreeNode(6);

	root.left.left = new TreeNode(2);
	root.left.right = new TreeNode(4);

	root.right.right = new TreeNode(7);

	FindTarget(root, 14).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public HashSet<int> valuesSet = new HashSet<int>();

public bool FindTarget(TreeNode root, int k)
{
	if (root == null)
	{
		return false;
	}

	var diff = k - root.val;

	if (valuesSet.Contains(diff) || root.val == k)
	{
		return true;
	}

	valuesSet.Add(root.val);

	return FindTarget(root.left, k) || FindTarget(root.right, k);
}