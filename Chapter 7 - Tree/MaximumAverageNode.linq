<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(2);
	root.left = new TreeNode(20);
	root.right = new TreeNode(14);

	root.left.left = new TreeNode(-1);
	root.left.right = new TreeNode(1);

	root.right.left = new TreeNode(5);
	root.right.right = new TreeNode(-1);
	
	MaximumAverageNode(root).Dump();
}

public class TreeNode
{
	public TreeNode left { get; set; }
	public TreeNode right { get; set; }
	
	public int val;
	
	public TreeNode(int val)
	{
		this.val = val;
	}
}


public int maxAverage = int.MinValue;
public TreeNode maxRoot;

public TreeNode MaximumAverageNode(TreeNode root)
{
	if(root == null || (root.left == null && root.right == null))
	{
		return root;
	}

	Average(root).Dump();
	maxAverage.Dump();
	
	return maxRoot;
}

public class Result
{
	public int val {get; set;}

	public int count { get; set; }
	
	public Result(int val, int count)
	{
		this.val = val;
		this.count = count;
	}
}

public Result Average(TreeNode node)
{
	if(node == null)
	{
		return new Result(0, 0);
	}
	
	if(node.left == null && node.right == null)
	{
		if(node.val > maxAverage)
		{
			maxAverage = node.val;
			maxRoot = node;
		}
		
		return new Result(node.val, 1);
	}

	var left = Average(node.left);
	var right = Average(node.right);
	
	var sum = left.val + right.val + node.val;
	
	var count = left.count + right.count + 1;
	
	var average = sum/count;
	
	if(average > maxAverage)
	{
		maxAverage = average;
		maxRoot =  node;
	}
	
	return new Result(sum, count);
}