<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,0,3,5, 0};
	
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
		if (nums[i] != 0)
		{
			Swap(nums, i, j);
			j++;
		}
	}
}

public void Swap(int[] nums, int i , int j)
{
	var temp = nums[i];
	nums[i] = nums[j];
	nums[j] = temp;
}
