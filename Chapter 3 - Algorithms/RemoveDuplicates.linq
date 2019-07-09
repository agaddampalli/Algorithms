<Query Kind="Program" />

void Main()
{
	var input = new int[] { 0, 1, 1 };

	RemoveDuplicates(input).Dump();
}

public int RemoveDuplicates(int[] nums)
{
	int dupIndex = 0;
	if (nums == null || nums.Length == 0)
	{
		return 0;
	}

	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[dupIndex] != (nums[i]))
		{
			dupIndex++;
			nums[dupIndex] = nums[i];

		}
	}
	return dupIndex + 1;
}
