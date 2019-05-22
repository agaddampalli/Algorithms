<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);
//	root.left = new TreeNode(1);
		root.right = new TreeNode(30);

	root.right.left = new TreeNode(10);
	root.right.left.right = new TreeNode(15);
	root.right.left.right.right = new TreeNode(45);

	IsValidBST(root).Dump();

	IsValid(root).Dump();
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
	public bool val;

	public int? lowestVal;

	public int? highestVal;

	public Result(bool v, int? l, int? h)
	{
		val = v;
		lowestVal = l;
		highestVal = h;
	}
}

public bool IsValidBST(TreeNode root)
{
	if (root == null)
	{
		return true;
	}

	var queue = new Queue<TreeNode>();
	queue.Enqueue(root);

	while (queue.Count != 0)
	{
		var node = queue.Dequeue();

		if (node.left != null)
		{
			if (node.val < node.left.val)
			{
				return false;
			}
			queue.Enqueue(node.left);
		}

		if (node.right != null)
		{
			if (node.val > node.right.val)
			{
				return false;
			}
			queue.Enqueue(node.right);
		}
	}

	return true;
}

private Result IsValid(TreeNode node)
{
	if (node == null)
	{
		return new Result(true, null, null);
	}

	if (node.left == null && node.right == null)
	{
		return new Result(true, node.val, node.val);
	}

	var leftResult = IsValid(node.left);
	var rightResult = IsValid(node.right);


	bool lresult = leftResult.val;
	if (leftResult.lowestVal != null && leftResult.highestVal != null)
	{
		lresult = lresult && node.val > leftResult.lowestVal && node.val > leftResult.highestVal && node.val > node.left.val;
	}


	bool rresult = rightResult.val;
	if (rightResult.lowestVal != null && rightResult.highestVal != null)
	{
		rresult = rresult && node.val < rightResult.lowestVal && node.val < rightResult.highestVal && node.val < node.right.val;
	}

	int? lowVal = null;
	int? highVal = null;
	if(leftResult.lowestVal != null && rightResult.lowestVal == null)
	{
		lowVal = leftResult.lowestVal.Value;
	}
	else if(leftResult.lowestVal == null && rightResult.lowestVal != null)
	{
		lowVal = rightResult.lowestVal.Value;
	}
	else if (leftResult.lowestVal != null && rightResult.lowestVal != null)
	{
		lowVal = leftResult.lowestVal.Value > rightResult.lowestVal.Value 
		? rightResult.lowestVal.Value : leftResult.lowestVal.Value;
	}

	if (leftResult.highestVal != null && rightResult.highestVal == null)
	{
		highVal = leftResult.highestVal.Value;
	}
	else if (leftResult.highestVal == null && rightResult.highestVal != null)
	{
		highVal = rightResult.highestVal.Value;
	}
	else if (leftResult.highestVal != null && rightResult.highestVal != null)
	{
		highVal = leftResult.highestVal.Value < rightResult.highestVal.Value
		? rightResult.highestVal.Value : leftResult.highestVal.Value;
	}

	return new Result(lresult && rresult, lowVal, highVal);
}