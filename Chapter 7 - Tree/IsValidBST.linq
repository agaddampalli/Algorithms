<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(2147483647);
		root.left = new TreeNode(1);
//	root.right = new TreeNode(30);

//	root.right.left = new TreeNode(1);
//	root.right.left.right = new TreeNode(15);
//	root.right.left.right.right = new TreeNode(45);

	IsValidBST(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public bool IsValidBST(TreeNode root)
{
	if (root == null)
	{
		return true;
	}

	var queue = new Queue<Tuple<long, TreeNode, long>>();
	queue.Enqueue(Tuple.Create(Int64.MinValue, root, Int64.MaxValue));

	while (queue.Count > 0)
	{
		var tuple = queue.Dequeue();
		var left = tuple.Item1;
		var node = tuple.Item2;
		var right = tuple.Item3;

		if(node.val <= left || node.val >= right)
		{
			return false;
		}
		
		if (node.left != null)
		{
			queue.Enqueue(Tuple.Create(left, node.left, (long)node.val));
		}

		if (node.right != null)
		{
			queue.Enqueue(Tuple.Create((long)node.val, node.right, right));
		}
	}

	return true;
}