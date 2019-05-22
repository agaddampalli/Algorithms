<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);
	root.left = new TreeNode(9);
	root.right = new TreeNode(20);

	root.left.left = new TreeNode(15);
	root.left.right = new TreeNode(7);
	root.right.left = new TreeNode(10);
	root.right.right = new TreeNode(8);
	

	root.left.left.left = new TreeNode(6);
	root.left.left.right = new TreeNode(1);


	ZigzagLevelOrder(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
{
	var output = new List<IList<int>>();

	if (root == null)
	{
		return output;
	}

	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	bool isOdd = true;
	while (queue.Count != 0)
	{
		var count = queue.Count;
		var list = new List<int>();
		for (int i = 0; i < count; i++)
		{
			var node = queue.Dequeue();
			list.Add(node.val);

			if (node.left != null)
			{
				queue.Enqueue(node.left);
			}

			if (node.right != null)
			{
				queue.Enqueue(node.right);
			}
		}
		
		isOdd = !isOdd;
		if(isOdd)
		{
			list.Reverse();
		}
		output.Add(list);
	}

	return output;
}
