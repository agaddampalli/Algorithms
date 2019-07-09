<Query Kind="Program" />

void Main()
{
	
}

public class TreeNode
{
	public int val {get; set;}

	public TreeNode left { get; set; }
	public TreeNode right { get; set; }
	
	public TreeNode(int val)
	{
		this.val = val;
	}

	public TreeNode(int val, TreeNode left, TreeNode right)
	{
		this.val = val;
		this.left = left;
		this.right = right;
	}
}

public void PrintLeft(TreeNode root)
{
	leftViewUtil(root, 1);
}

public int max_level = 0;
public virtual void leftViewUtil(TreeNode node, int level)
{
	// Base Case  
	if (node == null)
	{
		return;
	}

	// If this is the first node of its level  
	if (max_level < level)
	{
		Console.Write(" " + node.val);
		max_level = level;
	}

	// Recur for left and right subtrees  
	leftViewUtil(node.left, level + 1);
	leftViewUtil(node.right, level + 1);
}

