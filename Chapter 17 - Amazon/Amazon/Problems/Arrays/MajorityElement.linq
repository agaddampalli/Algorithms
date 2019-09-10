<Query Kind="Program" />

void Main()
{
	var nums = new int[] {3,2,3,2,3,2,2,1};
	
	MajorityElement(nums).Dump();
}

public int MajorityElement(int[] nums)
{
	var count = 0;
	var num = nums[0];
	
	for (int i = 1; i < nums.Length; i++)
	{
		if (count == 0)
		{
			num = nums[i];
		}
		
		if(nums[i] == num)
		{
			count++;
		}
		else
		{
			count--;
		}
	}
	
	return num;
}
