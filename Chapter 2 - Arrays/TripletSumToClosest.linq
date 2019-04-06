<Query Kind="Program" />

void Main()
{
	ThreeSumClosest(new int[]{-3,-2,-5,3,-4}, -1).Dump();
}

public int ThreeSumClosest(int[] nums, int target)
{
	Array.Sort(nums);

	if (nums.Length <= 2) return 0;
	
	var mid = nums.Length/2;
	var result = nums[mid-1] + nums[mid] +nums[mid+1];
	
	for (int i = 0; i < nums.Length - 2; i++)
	{
		int j = i + 1;
		int k = nums.Length - 1;
		while (j < k)
		{
			var sum = nums[i] + nums[j] + nums[k];
			if (Math.Abs(sum-target) <= Math.Abs(result-target))
			{
				result = sum;
				if(result == target) return result;
			}
			
			if(sum > target)
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