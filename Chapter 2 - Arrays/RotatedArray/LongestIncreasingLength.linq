<Query Kind="Program" />

void Main()
{
	var nums = new int[] {10,9,2,5,3,7,101,18};

	LengthOfLIS(nums).Dump();
	LengthOfLISWithDP(nums).Dump();
}

public int LengthOfLIS(int[] nums)
{
	var memo = new int[nums.Length+1][];
	
	for (int i = 0; i < memo.Length; i++)
	{
		memo[i] = new int[nums.Length];
		for (int j = 0; j < nums.Length; j++)
		{
			memo[i][j] = -1;
		}
	}
	
	LengthOfLISWithMemo(nums, -1, 0, memo).Dump();
	return LengthOfLIS(nums, int.MinValue, 0);
}

public int LengthOfLIS(int[] nums, int prev, int index)
{
	if(index == nums.Length)
	{
		return 0;
	}
	
	var currentLength = 0;
	if(nums[index] > prev)
	{
		currentLength = 1 + LengthOfLIS(nums, nums[index] , index + 1);
	}
	
	var nextLength =  LengthOfLIS(nums, prev , index + 1);
	
	return Math.Max(currentLength, nextLength);
}

public int LengthOfLISWithMemo(int[] nums, int prevIndex, int index, int[][] memo)
{
	if (index == nums.Length)
	{
		return 0;
	}
	
	if(memo[prevIndex +1][index] >= 0)
	{
		return memo[prevIndex +1][index];
	}
	
	var currentLength = 0;
	if (prevIndex < 0  || nums[index] > nums[prevIndex])
	{
		currentLength = 1 + LengthOfLISWithMemo(nums, index, index + 1, memo);
	}

	var nextLength = LengthOfLISWithMemo(nums, prevIndex, index + 1, memo);

	memo[prevIndex +1][index] = Math.Max(currentLength, nextLength);
	
	return memo[prevIndex +1][index];
}

public int LengthOfLISWithDP(int[] nums)
{
	if(nums == null || nums.Length == 0)
	{
		return 0;
	}
	
	var maxLength = 1;
	var dp = new int[nums.Length];
	dp[0] = 1;
	for (int i = 1; i < nums.Length; i++)
	{
		var count = 0;
		for (int j = 0; j < nums.Length; j++)
		{
			if(nums[i]> nums[j])
			{
				count = Math.Max(count, dp[j]);
			}
		}
		
		dp[i] = count + 1;
		maxLength = Math.Max(dp[i], maxLength);
	}
	
	return maxLength;
}