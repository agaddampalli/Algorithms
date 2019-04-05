<Query Kind="Program" />

void Main()
{
	ThreeSum(new int[]{-1, 0}).Dump();
}

public IList<IList<int>> ThreeSum(int[] nums)
{
	Array.Sort(nums);
	var result =  new List<IList<int>>();
		
	if(nums.Length==0) return result;
	
	for (int i = 0; i < nums.Length-2; i++)
	{
		if (i > 0 && nums[i] == nums[i - 1])
		{
			continue;
		}
		
		int j = i+1;
		int k = nums.Length-1;
		while(j < k)
		{
			var sum = nums[i] +nums[j]+nums[k];
			
			if(sum == 0)
			{
				result.Add(new List<int> {nums[i], nums[j], nums[k]});
				j++;
				k--;
				while (j < k && nums[j] == nums[j - 1]) j++;  
				while (j < k && nums[k] == nums[k + 1]) k--;  
			}
			else if(sum > 0)
			{
				k--;
			}
			else
			{
				j++;
			}
		}
	}
	
	return result;
}