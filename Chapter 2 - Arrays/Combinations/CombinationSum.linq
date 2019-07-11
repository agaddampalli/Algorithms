<Query Kind="Program" />

void Main()
{
	CombinationSum(new int[] { 8, 7, 4, 3 }, 11).Dump();
}

public IList<IList<int>> CombinationSum(int[] candidates, int target)
{
	var output = new List<IList<int>>();

	Combination(candidates, target, new List<int>(), output, 0);

	return output;
}

public void Combination(int[] nums, int target, List<int> temp, List<IList<int>> output, int level)
{
	if (target == 0)
	{
		output.Add(new List<int>(temp));
		return;
	}

	for (var i = level; i < nums.Length; i++)
	{
		if (nums[i] == target)
		{
			temp.Add(nums[i]);
			output.Add(new List<int>(temp));
			temp.RemoveAt(temp.Count - 1);
		}
		else if (nums[i] < target)
		{
			temp.Add(nums[i]);
			Combination(nums, target - nums[i], temp, output, i);
			temp.RemoveAt(temp.Count - 1);
		}
	}
}