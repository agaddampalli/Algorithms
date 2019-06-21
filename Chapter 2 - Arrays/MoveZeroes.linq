<Query Kind="Program" />

void Main()
{
	var nums = new int[] {2,1};
	
	MoveZeroes(nums);
	
	nums.Dump();
}

public void MoveZeroes(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return;
	}
	
	int j = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if(nums[i] != 0)
		{
			nums[j] = nums[i];
			if (i > j)
			{
				nums[i] = 0;
			}
			j++;
		}
	}

}
