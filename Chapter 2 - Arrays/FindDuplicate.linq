<Query Kind="Program" />

void Main()
{
	var input = new int[]{1,3,4,8,7,5, 6, 9,8,2};
	
	FindDuplicate(input).Dump();
}

public int FindDuplicate(int[] nums)
{
	if (nums.Length > 1)
	{
		int slow = nums[0];
		int fast = nums[nums[0]];
		while (slow != fast)
		{
			slow = nums[slow];
			fast = nums[nums[fast]];
		}

		fast = 0;
		while (fast != slow)
		{
			fast = nums[fast];
			slow = nums[slow];
		}
		return slow;
	}
	
	return -1;
	
	Array.Sort(nums);
	
	for (int i = 0; i < nums.Length-1; i++)
	{
		if(nums[i] == nums[i+1])
		{
			return nums[i];
		}
	}
	
	return 0;
}