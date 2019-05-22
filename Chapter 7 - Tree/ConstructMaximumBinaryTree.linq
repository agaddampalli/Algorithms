<Query Kind="Program" />

void Main()
{
	var input = new int[] { 3, 2, 1, 6, 0, 5};

	ConstructMaximumBinaryTree(input).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public TreeNode ConstructMaximumBinaryTree(int[] nums)
{
	return ConstructMaximumBinaryTree(nums, 0, nums.Length-1);
}

public TreeNode ConstructMaximumBinaryTree(int[] nums, int start, int end)
{
	if(start > end)
	{
		return null;
	}
	
	if(start == end)
	{
		return new TreeNode(nums[start]);
	}
	
	var maxIndex = FindMaxIndex(nums, start, end);
	
	var treeNode = new TreeNode(nums[maxIndex]);
	
	treeNode.left = ConstructMaximumBinaryTree(nums, start, maxIndex-1);
	treeNode.right = ConstructMaximumBinaryTree(nums, maxIndex+1, end);
	
	return treeNode;
}

private static int FindMaxIndex(int[] nums, int start, int end)
{
	var maxValue = nums[start];
	var maxIndex = start;
	for (int i = start+1; i <= end; i++)
	{
		if(nums[i] > maxValue)
		{
			maxValue = nums[i];
			maxIndex = i;
		}
	}
	
	return maxIndex;
}