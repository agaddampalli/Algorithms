<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);
	root.left = new TreeNode(1);
	root.right = new TreeNode(4);


	root.left.left = new TreeNode(2);
	root.right.right = new TreeNode(5);
	
	ClosestValue(root, 0.428571).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public int ClosestValue(TreeNode root, double target)
{
	if(root == null)
	{
		return 0;
	}
	
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	
	var lastdiff = Math.Abs(root.val-target);
	var output = root.val;
	
	while (queue.Count != 0)
	{
		var node = queue.Dequeue();
		if(Math.Abs(node.val-target) <= lastdiff)
		{
			output = node.val;
			lastdiff = Math.Abs(node.val-target);
		}
			
		if(node.left != null)
		{
			queue.Enqueue(node.left);
		}

		if (node.right != null)
		{
			queue.Enqueue(node.right);
		}
	}
	
	return output;
}