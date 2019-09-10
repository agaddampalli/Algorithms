<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(4);
	root.left = new TreeNode(3);
	root.right = new TreeNode(6);

	root.right.right = new TreeNode(5);
	root.right.left = new TreeNode(7);
	
	LowestCommonAncestor(root, root.right , root.right.right).Dump();
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
	if (root == null)
	{
		return root;
	}

	var val = root.val;
	var qval = q.val;
	var pval = p.val;
	
	if(qval > val && pval > val)
	{
		return LowestCommonAncestor(root.right, p, q);
	}
	else if(qval < val && pval < val)
	{
		return LowestCommonAncestor(root.left, p, q);
	}
	else
	{
		return root;
	}
}
