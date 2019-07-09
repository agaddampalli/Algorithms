<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	
	root.left = new TreeNode(2);
	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(5);
	root.left.right.left = new TreeNode(7);
	root.left.right.right = new TreeNode(8);

	root.right = new TreeNode(3);
	root.right.left = new TreeNode(6);
	root.right.left.left = new TreeNode(9);
	root.right.left.right = new TreeNode(10);
	
	BoundaryOfBinaryTree(root).Dump();
}

public class TreeNode
{
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) { val = x; }
 }
 
public bool isLeaf(TreeNode t)
{
	return t.left == null && t.right == null;
}

public void AddLeaves(List<int> res, TreeNode root)
{
	if (isLeaf(root))
	{
		res.Add(root.val);
	}
	else
	{
		if (root.left != null)
		{
			AddLeaves(res, root.left);
		}
		if (root.right != null)
		{
			AddLeaves(res, root.right);
		}
	}
}

public List<int> BoundaryOfBinaryTree(TreeNode root)
{
	List<int> res = new List<int>();
	if (root == null)
	{
		return res;
	}
	if (!isLeaf(root))
	{
		res.Add(root.val);
	}
	TreeNode t = root.left;
	while (t != null)
	{
		if (!isLeaf(t))
		{
			res.Add(t.val);
		}
		if (t.left != null)
		{
			t = t.left;
		}
		else
		{
			t = t.right;
		}

	}
	AddLeaves(res, root);
	Stack<int> s = new Stack<int>();
	t = root.right;
	while (t != null)
	{
		if (!isLeaf(t))
		{
			s.Push(t.val);
		}
		if (t.right != null)
		{
			t = t.right;
		}
		else
		{
			t = t.left;
		}
	}
	while (s.Count != 0)
	{
		res.Add(s.Pop());
	}
	return res;
}
