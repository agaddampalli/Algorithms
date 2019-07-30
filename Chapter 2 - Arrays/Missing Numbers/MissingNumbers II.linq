<Query Kind="Program" />

void Main()
{

	FindMissingNumbers(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }).Dump();
}

public List<int> FindMissingNumbers(int[] nums)
{

	var output = new List<int>();

	for (int i = 0; i < nums.Length; i++)
	{
		var index = Math.Abs(nums[i]) - 1;

		if (nums[index] < 0)
		{
			continue;
		}

		nums[index] = -nums[index];
	}

	for (int i = 0; i < nums.Length; i++)
	{
		if(nums[i] > 0)
		{
			output.Add(i+1);
		}
		
	}
	return output;
}
