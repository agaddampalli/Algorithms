<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(0);
	root.right = new TreeNode(1);

	root.right.right = new TreeNode(2);
	root.right.right.left = new TreeNode(3);
	
	BoundaryOfBinaryTree(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public List<int> BoundaryOfBinaryTree(TreeNode root)
{
	var output = new List<int>();
	
	if(root == null)
	{
		return output;
	}
	
	if(!IsLeafNode(root))
	{
		output.Add(root.val);
	}
	
	var left = root.left;
	
	while(left != null)
	{
		if(!IsLeafNode(left))
		{
			output.Add(left.val);
		}
		
		if(left.left != null)
		{
			left = left.left;
		}
		else
		{
			left = left.right;
		}
	}
	
	AddLeaves(root, output);
	
	var stack = new Stack<int>();
	var right = root.right;
	
	while(right!= null)
	{
		if (!IsLeafNode(right))
		{
			stack.Push(right.val);
		}

		if (right.right != null)
		{
			right = right.right;
		}
		else
		{
			right = right.left;
		}
	}
	
	while(stack.Any())
	{
		output.Add(stack.Pop());
	}

	return output;
}

public void AddLeaves(TreeNode root, List<int> output)
{
	if(IsLeafNode(root))
	{
		output.Add(root.val);
	}
	else
	{
		if (root.left != null)
		{
			AddLeaves(root.left, output);
		}
		else
		{
			AddLeaves(root.right, output);
		}
	}
}

public bool IsLeafNode(TreeNode node)
{
	return node.left == null && node.right == null;
}
