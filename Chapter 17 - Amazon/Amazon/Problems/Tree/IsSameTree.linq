<Query Kind="Program" />

void Main()
{
	var p = new TreeNode(1);
	p.right = new TreeNode(3);
	
	var q = new TreeNode(1);
	q.right = new TreeNode(3);
	
	IsSameTree(p,q).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public bool IsSameTree(TreeNode p, TreeNode q)
{
	if((p == null && q != null) || (p != null && q == null))
	{
		return false;
	}
	
	if(p?.val != q?.val)
	{
		return false;
	}
	
	if(p == null && q == null)
	{
		return true;
	}
	
	if(!IsSameTree(p.left, q.left))
	{
		return false;
	}

	if (!IsSameTree(p.right, q.right))
	{
		return false;
	}
	
	return true;
}
