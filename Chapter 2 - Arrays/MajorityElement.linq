<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 2, 2, 1, 1, 1, 2, 2 };

	MajorityElement(nums).Dump();
}

public int MajorityElement(int[] nums)
{
	if (nums == null || nums.Length == 0) return 0;
	int count = 1;
	int res = nums[0];
	for (int i = 1; i < nums.Length; i++)
	{
		if (count == 0)
		{
			res = nums[i];
			count = 1;
			continue;
		}

		if (res != nums[i])
		{
			count--;
		}
		else
		{
			count++;
		}
	}

	return res;
}