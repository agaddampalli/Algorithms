<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);
	root.left = new TreeNode(5);
	root.right = new TreeNode(1);

	root.left.left = new TreeNode(6);
	root.left.right = new TreeNode(2);
	root.right.right = new TreeNode(3);

	root.left.right.left = new TreeNode(7);
	root.left.right.right = new TreeNode(4);



	LowestCommonAncestor(root, root.left.left ,root.left.right.right).Dump();
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
{
	if(root == null || root == p || root == q)
	{
		return root;
	}

	var left = LowestCommonAncestor(root.left, p, q);
	var right = LowestCommonAncestor(root.right, p, q);
	
	if(left != null && right != null)
	{
		return root;
	}
	
	return left ?? right;
}