<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(5);


	MaxDepth(root).Dump();
}


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public int MaxDepth(TreeNode root)
{
	if (root == null)
	{
		return 0;
	}

	var leftHeight = MaxDepth(root.left) + 1;
	var rightHeight = MaxDepth(root.right) + 1;

	return leftHeight > rightHeight ? leftHeight : rightHeight;
}