<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(0);
	root.left.right.right = new TreeNode(2);
//
//	root.right.left = new TreeNode(1);
//	root.right.right = new TreeNode(7);
//	root.right.left.left = new TreeNode(5);

	var node = new TreeNode(5);
	Inorder(root);
	InorderSuccessor(root, node).Dump();
}

public void Inorder(TreeNode root)
{
	if (root == null)
	{
		return;
	}

	Inorder(root.left);

	root.val.Dump();

	Inorder(root.right);
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
{
	if(p == null)
	{
		return root;
	}


	var result = new Result();
	
	InorderSuccessor(root,p,result);
	
	return result.Output;
}

public void InorderSuccessor(TreeNode root, TreeNode p, Result result)
{
	if (root == null)
	{
		return;
	}

	InorderSuccessor(root.left, p, result);

	if (root.val > p.val)
	{
		if (result.Output == null || root.val < result.Output.val)
		{
			result.Output = root;
		}
	}
	
	InorderSuccessor(root.right, p, result);
}

public class Result
{
	public TreeNode Output {get; set;}
}