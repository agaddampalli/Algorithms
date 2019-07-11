<Query Kind="Program" />

void Main()
{
	
}

public IList<IList<int>> CombinationSum3(int k, int n)
{
	var output = new List<IList<int>>();


	Combination(candidates, target, new List<int>(), output, 0);

	return output;
}

public void Combination(int[] nums, int target, List<int> temp, List<IList<int>> output, int level)
{
	if (target < 0)
		return;

	if (target == 0)
	{
		output.Add(new List<int>(temp));
		return;
	}

	for (var i = level; i < nums.Length; i++)
	{
		if (i != level && nums[i] == nums[i - 1])
		{
			continue;
		}

		temp.Add(nums[i]);
		Combination(nums, target - nums[i], temp, output, i + 1);
		temp.RemoveAt(temp.Count - 1);
	}
}