<Query Kind="Program" />

void Main()
{
	var input = new int[]{1,2,3,4,5};
	
	FirstMissingPositive(input).Dump();
	
}

public int FirstMissingPositive(int[] nums)
{
	bool contains  = false;
	
	for (int i = 0; i < nums.Length; i++)
	{
		if(nums[i] == 1)
		{
			contains = true;
			break;
		}
	}
	
	if(!contains)
	{
		return 1;
	}
	
	if(nums.Length == 1)
	{
		return 2;
	}
	
	for (int i = 0; i < nums.Length; i++)
	{
		if(nums[i] <= 0 || nums[i] > nums.Length)
		{
			nums[i] = 1;
		}
	}
	
	for (int i = 0; i < nums.Length; i++)
	{
		var index = Math.Abs(nums[i])-1;
		
		if(nums[index] < 0)
		{
			continue;
		}
		
		nums[index] = -nums[index];
	}
	
	for (int i = 0; i < nums.Length; i++)
	{
		if(nums[i] > 0)
		{
			return i+1;
		}
	}
	
	return nums.Length+1;
}
