<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 1, 2, 3, 5, 6, 9, 11 };


	FindLowest(nums, 11).Dump();

	var nums1 = new int[] { 1, 6, 6, 6, 6, 6, 11 };
	FindLowestRange(nums1, 6).Dump(); ;
	FindHighestRange(nums1, 6).Dump(); ;
}

public int FindLowest(int[] nums, int k)
{

	if (k < nums[0])
	{
		return -1;
	}

	if (k > nums[nums.Length - 1])
	{
		return nums[nums.Length - 1];
	}

	int left = 0;
	int right = nums.Length;
	var temp = (left + right) / 2;

	while (left < right)
	{
		var mid = (left + right) / 2;
		var val = nums[mid];

		if (k <= val)
		{
			if (mid <= temp)
			{
				right = mid;
			}
			else
			{
				right = mid - 1;
			}
		}
		else
		{
			if (mid <= temp)
			{
				left = mid + 1;
			}
			else
			{
				left = mid;
			}
		}
	}

	return nums[left % nums.Length];
}

public int FindLowestRange(int[] nums, int target)
{
	int left = 0;
	int right = nums.Length - 1;

	while (left < right)
	{
		var mid = (left + right) / 2;
		var val = nums[mid];

		if (nums[mid] < target)
		{
			left = mid + 1;
		}
		else
		{
			right = mid;
		}
	}

	return left;
}

public int FindHighestRange(int[] nums, int target)
{
	var left = 0;
	var right = nums.Length - 1;

	while (left < right)
	{
		var mid = (left + right + 1) / 2;

		if (nums[mid] <= target)
		{
			left = mid;
		}
		else
		{
			right = mid - 1;
		}
	}

	return right;
}