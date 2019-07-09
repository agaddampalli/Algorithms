<Query Kind="Program" />

void Main()
{
	var input = new int[] { 3, 4, 5, 0,0,1,2, 2 };

	FindMin(input).Dump(); ;
}

public int FindMin(int[] nums)
{
	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[i] < nums[i - 1])
			return nums[i];
	}

	return nums[0];
}

