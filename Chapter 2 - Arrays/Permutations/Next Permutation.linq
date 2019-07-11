<Query Kind="Program" />

void Main()
{
	NextPermutation(new int[] {1, 2, 5, 6, 3});
}

public void NextPermutation(int[] nums)
{
	
	int x = -1;
	int y = -1;

	//step1
	for (int i = 0; i < nums.Length - 1; i++)
	{
		if (nums[i] < nums[i + 1])
		{
			x = i;
		}
	}

	if (x == -1)
	{
		Reverse(nums, 0, nums.Length - 1);;
	}
	else
	{
		//step 2
		for (int i = 0; i < nums.Length; i++)
		{
			if (nums[x] < nums[i])
			{
				y = i;
			}
		}

		Swap(nums, x, y);

		Reverse(nums, x + 1, nums.Length - 1);
	}
	
	nums.Dump();
}

public void Swap(int[] s, int i, int j)
{
	int temp = s[i];
	s[i] = s[j];
	s[j] = temp;
}

public void Reverse(int[] s, int start, int end)
{
	while (start < end)
	{
		Swap(s, start++, end--);
	}
}
