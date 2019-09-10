<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 1, 7, 9, 2 };

	Rob(nums).Dump();
	RobInCircle(nums).Dump();
}

public int Rob(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return 0;
	}

	if (nums.Length == 1)
	{
		return nums[0];
	}

	var dp = new int[nums.Length];

	dp[0] = nums[0];
	dp[1] = Math.Max(nums[0], nums[1]);

	for (int i = 2; i < nums.Length; i++)
	{
		dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
	}

	return dp[nums.Length - 1];
}


public int RobInCircle(int[] nums)
{
	if (nums == null)
	{
		return 0;
	}

	if (nums.Length < 1)
	{
		return nums.Length == 1 ? nums[0] : 0;
	}

	if (nums.Length == 2)
	{
		return Math.Max(nums[0], nums[1]);
	}
	
	var dp = new int[nums.Length - 1];

	dp[0] = nums[0];
	dp[1] = Math.Max(nums[0], nums[1]);

	for (int i = 2; i < nums.Length - 1; i++)
	{
		dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
	}

	var excludeLast = dp[dp.Length - 1];

	dp = new int[nums.Length - 1];
	dp[0] = nums[1];
	dp[1] = Math.Max(nums[1], nums[2]);
	
	for (int i = 3; i < nums.Length; i++)
	{
		dp[i-1] = Math.Max(dp[(i-1) - 2] + nums[i], dp[(i-1) - 1]);
	}

	return Math.Max(excludeLast, dp[dp.Length - 1]);
}