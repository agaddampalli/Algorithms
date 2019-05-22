<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(2);

	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(5);
	root.right.right = new TreeNode(4);


	IsSymmetric(root).Dump();
}


public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public bool IsSymmetricIterative(TreeNode root)
{
	Stack<TreeNode> stack = new Stack<TreeNode>();
	stack.Push(root.left);
	stack.Push(root.right);

	TreeNode node1;
	TreeNode node2;
	while (stack.Count != 0)
	{
		node1 = stack.Pop();
		node2 = stack.Pop();

		if (node1 == null && node2 == null)
		{
			continue;
		}

		if (node1 == null || node2 == null)
		{
			return false;
		}

		if (node1.val != node2.val)
		{
			return false;
		}

		stack.Push(node1.left);
		stack.Push(node2.right);
		stack.Push(node1.right);
		stack.Push(node2.left);
	}

	return true;
}

public bool IsSymmetricRecursive(TreeNode root)
{
	if (root == null) return true;
	return Symmetric(root.left, root.right);
}

private bool Symmetric(TreeNode root1, TreeNode root2)
{
	if (root1 == null && root2 == null) return true;
	if (root1 == null || root2 == null) return false;
	if (root1.val != root2.val) return false;
	return Symmetric(root1.left, root2.right) && Symmetric(root1.right, root2.left);
}

public bool IsSymmetric(TreeNode root)
{
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);

	while (queue.Count != 0)
	{
		var count = queue.Count;
		var list = new List<int>();
		for (int i = 0; i < count; i++)
		{
			var node = queue.Dequeue();

			if (node == null)
			{
				list.Add(0);
			}
			else
			{
				list.Add(node.val);
				queue.Enqueue(node.left);
				queue.Enqueue(node.right);
			}
		}

		if (!IsPalindromeList(list))
		{
			return false;
		}
	}

	return true;
}

private bool IsPalindromeList(List<int> input)
{
	var length = input.Count - 1;
	var mid = length / 2 + 1;
	for (int i = 0; i < mid; i++)
	{
		if (input[i] != input[length - i])
		{
			return false;
		}
	}

	return true;
}

