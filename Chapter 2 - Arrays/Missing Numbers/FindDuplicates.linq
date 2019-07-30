<Query Kind="Program" />

void Main()
{

	FindDuplicatesExtraSpace(new int[] { 3, 3, 2, 2 }).Dump();
	FindDuplicates(new int[] { 4,3,2,7,8,2,3,1 }).Dump();
}

public IList<int> FindDuplicatesExtraSpace(int[] nums)
{

	var output = new List<int>();

	var temp = new int[nums.Length];

	for (int i = 0; i < nums.Length; i++)
	{
		temp[nums[i] - 1]++;
	}

	for (int i = 0; i < temp.Length; i++)
	{
		if (temp[i] > 1)
		{
			output.Add(i + 1);
		}
	}

	return output;
}

public IList<int> FindDuplicates(int[] nums)
{
	var output = new List<int>();

	for (int i = 0; i < nums.Length; i++)
	{
		int index = Math.Abs(nums[i]) - 1;

		if (nums[index] < 0)
			output.Add(index + 1);
		else
			nums[index] = -nums[index];
	}

	return output;
}

