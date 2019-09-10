<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(4);
	root.left = new TreeNode(1);
	root.right = new TreeNode(6);


	root.left.left = new TreeNode(0);
	root.left.right = new TreeNode(2);
	root.left.right.right = new TreeNode(3);

	root.right.left = new TreeNode(5);
	root.right.right = new TreeNode(7);
	root.right.right.right = new TreeNode(8);

	ConvertBST(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public TreeNode ConvertBST(TreeNode root)
{
	if (root == null)
	{
		return root;
	}

	ConvertBST(root, 0);

	return root;
}

public int ConvertBST(TreeNode root, int maximum)
{
	if (root == null)
	{
		return maximum;
	}

	var right = ConvertBST(root.right, maximum);

	root.val += right;

	return ConvertBST(root.left, root.val);
}