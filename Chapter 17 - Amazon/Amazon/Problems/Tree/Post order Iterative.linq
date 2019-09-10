<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	PostorderTraversal1(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public IList<int> PostorderTraversal(TreeNode root)
{
	var output = new List<int>();

	if (root == null)
	{
		return output;
	}

	var stack = new Stack<TreeNode>();
	var visited = new HashSet<TreeNode>();
	stack.Push(root);

	while (stack.Any())
	{
		var node = stack.Pop();

		if ((node.left == null && node.right == null) || visited.Contains(node))
		{
			output.Add(node.val);
		}
		else
		{
			stack.Push(node);
			visited.Add(node);
			if (node.right != null)
			{
				stack.Push(node.right);
			}

			if (node.left != null)
			{
				stack.Push(node.left);
			}
		}
	}

	return output;
}

public IList<int> PostorderTraversal1(TreeNode root)
{
	var output = new List<int>();

	if (root == null)
	{
		return output;
	}

	var stack = new Stack<TreeNode>();
	stack.Push(root);

	while (stack.Any())
	{
		var node = stack.Pop();
		output.Add(node.val);
		if (node.left != null)
		{
			stack.Push(node.left);
		}
		
		if (node.right != null)
		{
			stack.Push(node.right);
		}
	}

	output.Reverse();
	
	return output;
}