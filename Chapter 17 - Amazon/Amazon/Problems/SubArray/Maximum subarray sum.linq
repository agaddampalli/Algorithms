<Query Kind="Program" />

void Main()
{
	var input = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

	MaxSubArraySum(input).Dump();
	MaxSubArray(input).Dump();
}

public int MaxSubArraySum(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return int.MaxValue;
	}

	var maxSum = nums[0];
	var maxAtIndex = nums[0];
	for (int i = 1; i < nums.Length; i++)
	{
		maxAtIndex = Math.Max(nums[i], nums[i] + maxAtIndex);
		
		maxSum = Math.Max(maxSum, maxAtIndex);
	}

	return maxSum;
}

public List<int> MaxSubArray(int[] nums)
{
	var output = new List<int>();
	if (nums == null || nums.Length == 0)
	{
		return output;
	}

	var maxSum = nums[0];
	var maxAtIndex = nums[0];
	var startIndex = 0;
	var endIndex = 0;
	for (int i = 1; i < nums.Length; i++)
	{
		if(nums[i] < nums[i] + maxAtIndex)
		{
			maxAtIndex = nums[i] + maxAtIndex;
		}
		else
		{
			maxAtIndex = nums[i];
			startIndex = i;
		}
		
		if(maxSum < maxAtIndex)
		{
			endIndex = i;
			maxSum = maxAtIndex;
		}
	}
	
	for (int i = startIndex; i <= endIndex; i++)
	{
		output.Add(nums[i]);
	}
	
	return output;
}

