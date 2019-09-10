<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1};
	
	SearchInsert(nums,1).Dump();
}

public int SearchInsert(int[] nums, int target)
{
	if (nums == null)
	{
		return -1;
	}

	if (target > nums[nums.Length - 1])
	{
		return nums.Length;
	}

	if (target < nums[0])
	{
		return 0;
	}
	
	var left = 0;
	var right = nums.Length-1;
	
	while(left <= right)
	{
		var mid = (left+right)/2;
		
		if(nums[mid] == target || (mid > 0 && nums[mid] > target && nums[mid - 1] < target))
		{
			return mid;
		}
		else if(nums[mid] > target)
		{
			right = mid-1;
		}
		else
		{
			left = mid+1;
		}
	}
	
	return -1;
}
