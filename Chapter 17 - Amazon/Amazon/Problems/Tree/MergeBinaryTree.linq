<Query Kind="Program" />

void Main()
{
	
}

public class TreeNode
{
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) { val = x; }
 }

public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
{
	if(t1 == null && t2 == null)
	{
		return null;
	}
	
	if(t1 == null)
	{
		return t2;
	}

	if (t2 == null)
	{
		return t1;
	}
	
	var temp = t1.val + t2.val;
	
	var left = MergeTrees(t1.left, t2.left);
	var right = MergeTrees(t1.right, t2.right);
	
	t1.val = temp;
	t1.left = left;
	t1.right = right;
	
	return t1;
}

