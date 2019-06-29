<Query Kind="Program" />

void Main()
{
	var nums = new int[] {-2,3,-4};

	MaxSubArray(nums).Dump();
}

public int MaxSubArray(int[] nums)
{
	if(nums == null || nums.Length == 0)
	{
		return int.MaxValue;
	}

	int maxAtIndex = nums[0];
	int maxSum = nums[0];

	for (int i = 1; i < nums.Length; i++)
	{
		maxAtIndex = Math.Max(nums[i], maxAtIndex + nums[i]);
		
		maxSum = Math.Max(maxAtIndex, maxSum);
	}
	
	return maxSum;
}
