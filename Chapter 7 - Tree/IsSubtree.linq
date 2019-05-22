<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(1);
//	root.right = new TreeNode(5);
//
//	root.left.left = new TreeNode(1);
//	root.left.right = new TreeNode(2);

	var subtree = new TreeNode(1);
//	subtree.left = new TreeNode(1);
//	subtree.right = new TreeNode(2);
//
//	subtree.left.left = new TreeNode(1);

	IsSubtree(root, subtree).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public bool IsSubtree(TreeNode s, TreeNode t)
{
	if (s == null) return false;
	if (isSame(s, t)) return true;
	return IsSubtree(s.left, t) || IsSubtree(s.right, t);
}

private bool isSame(TreeNode s, TreeNode t)
{
	if (s == null && t == null) return true;
	if (s == null || t == null) return false;

	if (s.val != t.val) return false;

	return isSame(s.left, t.left) && isSame(s.right, t.right);
}