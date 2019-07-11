<Query Kind="Program" />

void Main()
{
	
var input = new int[]{1, 1, 2};

	Permute(input).Dump();
}

public List<IList<int>> Permute(int[] nums)
{
	var output = new List<IList<int>>();
	
	if(nums == null)
	{
		return output;
	}
	
	Permute(nums, new List<int>(), new bool[nums.Length], output);
	
	return output;
}

public void Permute(int[] nums, List<int> temp, bool[] used, List<IList<int>> output)
{
	if(temp.Count == nums.Length)
	{
		output.Add(new List<int>(temp));
		return;
	}
	
	for (int i = 0; i < nums.Length; i++)
	{
		if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]))
			continue;
			
		temp.Add(nums[i]);
		used[i] = true;
		Permute(nums, temp, used, output);
		used[i] = false;
		temp.RemoveAt(temp.Count-1);
	}
}
