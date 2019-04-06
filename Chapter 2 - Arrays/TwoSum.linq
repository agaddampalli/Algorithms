<Query Kind="Program" />

void Main()
{
	var input = new int[] {2, 7, 11, 15};
}

public int[] TwoSum(int[] nums, int target)
{

	Dictionary<int, int> numsDict = new Dictionary<int, int>();
	for (int i = 0; i < nums.Length; i++)
	{
		if (numsDict.TryGetValue(target - nums[i], out int index))
		{
			return new int[] { index, i };
		}

		numsDict.Add(nums[i], i);
	}

	return null;
}
