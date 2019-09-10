<Query Kind="Program" />

void Main()
{
	var nums = new int[] {2, 6, 4, 8, 10, 9, 15};
	
	FindUnsortedSubarray(nums).Dump();
}

//https://leetcode.com/problems/shortest-unsorted-continuous-subarray/
public int FindUnsortedSubarray(int[] nums)
{
	var min = int.MaxValue;
	var max = int.MinValue;

	var flag = false;
	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[i] < nums[i - 1])
		{
			flag = true;
		}

		if (flag && min > nums[i])
		{
			min = nums[i];
		}
	}

	flag = false;
	for (int i = nums.Length - 1; i > 0; i--)
	{
		if (nums[i] < nums[i - 1])
		{
			flag = true;
		}

		if (flag && max < nums[i - 1])
		{
			max = nums[i - 1];
		}
	}

	var start = 0;
	var end = 0;

	for (; start < nums.Length; start++)
	{
		if (min < nums[start])
		{
			break;
		}
	}

	for (end = nums.Length - 1; end >= 0; end--)
	{
		if (nums[end] < max)
		{
			break;
		}
	}


	return end - start < 0 ? 0 : end - start + 1;
}