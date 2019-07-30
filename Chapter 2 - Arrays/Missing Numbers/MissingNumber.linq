<Query Kind="Program" />

void Main()
{
	FindMissingNumbers(new int[] {0, 1, 2, 4}).Dump();
}

public int FindMissingNumbers(int[] nums)
{
	var expectedSum = 0;
	var actualSum = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		expectedSum += (i+1);
		actualSum += nums[i];
	}
	
	return expectedSum - actualSum;
}
