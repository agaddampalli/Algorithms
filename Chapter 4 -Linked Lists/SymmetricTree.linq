<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(2);


	root.left.left = new TreeNode(3);
	root.right.right = new TreeNode(3);

	IsSymmetricIterative(root).Dump();
	IsSymmetricRecursive(root, root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

private bool IsSymmetricRecursive(TreeNode node1, TreeNode node2)
{
	if (node1 == null && node2 == null) return true;
	if (node1 == null || node2 == null) return false;
	if (node1.val != node2.val) return false;
	return IsSymmetricRecursive(node1.left, node2.right) && IsSymmetricRecursive(node1.right, node2.left);
}

public bool IsSymmetricIterative(TreeNode root)
{
	if(root == null || (root.left == null && root.right == null))
	{
		return true;
	}

	var queue = new Queue<TreeNode>();
	queue.Enqueue(root.left);
	queue.Enqueue(root.right);
	
	while(queue.Count != 0)
	{
		var left = queue.Dequeue();
		var right = queue.Dequeue();
		
		if(left.val != right.val)
		{
			return false;
		}
	
		if(left.left != null)
		{
			queue.Enqueue(left.left);
			if(right.right == null)
			{
				return false;
			}
			queue.Enqueue(right.right);
		}

		if (left.left == null && right.right != null)
		{
			return false;
		}

		if (left.right != null)
		{
			queue.Enqueue(left.right);
			if (right.left == null)
			{
				return false;
			}
			queue.Enqueue(right.left);
		}

		if (left.right == null && right.left != null)
		{
			return false;
		}
	}
	
	return true;
}

public bool IsSymmetricSlow(TreeNode root)
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
