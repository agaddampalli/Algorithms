<Query Kind="Program" />

void Main()
{
	
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Result
{
	public int min;
	public int max;
	public int count;
	public bool isValid;
	
	public Result(int min, int max, int count, bool re)
	{
		this.min = min;
		this.max = max;
		this.count = count;
		this.isValid = re;
	}

	public Result(bool re)
	{
		this.isValid = re;
	}
}

public int LargestBSTSubtree(TreeNode root)
{
	int[] max = new int[1];
	helper(root, max);
	return max[0];
}

private Result helper(TreeNode root, int[] max)
{
	if (root == null) return new Result(int.MaxValue, int.MinValue, 0, true);

	Result left = helper(root.left, max);
	Result right = helper(root.right, max);

	if (left.isValid && right.isValid && root.val > left.max && root.val < right.min)
	{
		max[0] = Math.Max(max[0], left.count + right.count + 1);
		return new Result(left.min == int.MaxValue ? root.val : Math.Min(left.min, root.val),
						  right.max == int.MinValue ? root.val : Math.Max(right.max, root.val),
						  left.count + right.count + 1,
						  true);
	}

	return new Result(false);
}
