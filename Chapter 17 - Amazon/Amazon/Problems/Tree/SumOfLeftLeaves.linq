<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);

	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(5);
//	root.right.right.left = new TreeNode(10);
	
	SumOfLeftLeaves(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}


public int SumOfLeftLeaves(TreeNode root)
{
	if(root == null)
	{
		return 0;
	}
	
	var sum = 0;
	
	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);
	
	while(queue.Count!=0)
	{
		var node = queue.Dequeue();
		
		if(node.left != null)
		{
			if (node.left.left == null && node.left.right == null)
			{
				sum += node.left.val;
			}
			queue.Enqueue(node.left);
		}

		if (node.right != null)
		{
			queue.Enqueue(node.right);
		}
	}

	return sum;
}

