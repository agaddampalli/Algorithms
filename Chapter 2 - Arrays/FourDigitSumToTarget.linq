<Query Kind="Program" />

void Main()
{
	FourSum(new int[]{-3,-2,-1,0,0,1,2,3}, 0).Dump();
}

public IList<IList<int>> FourSum(int[] nums, int target)
{
	Array.Sort(nums);
	var result = new List<IList<int>>();

	if (nums.Length == 0) return result;
	
	for (int i = 0; i < nums.Length - 3; i++)
	{
		if (i > 0 && nums[i] == nums[i - 1])
		{
			continue;
		}

		int j = i + 1;
		int k = nums.Length - 1;
		while (j < k)
		{
			var x = j+1;
			k = nums.Length - 1;
			while(x < k)
			{
				var sum = nums[i] + nums[j] + nums[x] + nums[k];

				if (sum == target)
				{
					result.Add(new List<int> { nums[i], nums[j], nums[x], nums[k] });
					x++;
					while (x < k && nums[x] == nums[x - 1]) x++;
				}
				else if (sum > target)
				{
					k--;
				}
				else
				{
					x++;
				}
			}
			
			j++;
			while (j < k && nums[j] == nums[j - 1]) j++;
		}
	}

	return result;
}
