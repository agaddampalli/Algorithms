<Query Kind="Program" />

void Main()
{
	var nums = new int[] {5, 5, 6, 6, 1, 1, 2, 2};

	FindMinNumberInRotatedArray(nums).Dump();
	FindNumberInRotatedArray(nums, 5).Dump();
}

public int FindMinNumberInRotatedArray(int[] nums)
{
	var low = 0;
	var high = nums.Length -1;
	
	while(low < high)
	{
		while (nums[low] == nums[high] && low != high)
		{
			low++;
		}

		if(nums[low] <= nums[high])
		{
			return nums[low];
		}
		
		var mid = (low + high)/2;
		
		if(nums[mid] <= nums[low])
		{
			high = mid;
		}
		else
		{
			low = mid + 1;
		}
	}
	
	
	return nums[low];
}

public int FindNumberInRotatedArray(int[] nums, int k)
{
	var low = 0;
	var high = nums.Length - 1;

	while (low <= high)
	{
		var mid = (low + high) / 2;

		if(nums[mid] == k)
		{
			return mid;
		}
		
		else if(nums[mid] >= nums[low])
		{
			if(nums[mid] > k && nums[low] <= k)
			{
				high = mid -1;
			}
			else
			{
				low = mid + 1;
			}
		}
		else if(nums[mid] < nums[low])
		{
			if(nums[mid] < k && nums[high] >= k)
			{
				low = mid +1;
			}
			else
			{
				high = mid - 1;
			}
		}
		else
		{
			low++;
		}
	}


	return -1;
}