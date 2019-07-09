<Query Kind="Program" />

void Main()
{
	var input = new int[] {2,4,4,4,0};

	RemoveElement(input, 4).Dump();
}

public int RemoveElement(int[] nums, int val)
{
	if (nums == null || nums.Length == 0)
		return 0;

	int count = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] != val)
		{
			nums[count] = nums[i];
			count++;
		}


	}

nums.Dump();
	return count;
}

public int RemoveElement1(int[] nums, int val)
{
	if (nums == null || nums.Length == 0)
	{
		return 0;
	}
	
	int i = 0;
	int j = nums.Length-1;
	
	while(i < j)
	{
		while (j > 0 && nums[j] == val)
		{
			j--;
		}
		
		if(nums[i] == val && i < j)
		{
			Swap(i, j, nums);
			j--;
		}
		
		i++;
	}
	
	nums.Dump();
	
	for (int k = 0; k < nums.Length; k++)
	{
		if(nums[k] == val)
		{
			return k;
		}
	}	
	
	return nums.Length;
}

public void Swap(int i, int j, int[] nums)
{
	var temp = nums[j];
	nums[j] = nums[i];
	nums[i] = temp;
}