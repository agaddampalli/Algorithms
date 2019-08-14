<Query Kind="Program" />

void Main()
{
	var nums = new int[] {5,7,8,8,8,10};

	FindRange(nums, 8).Dump();
	FindRange1(nums, 8).Dump();
}

public List<int> FindRange(int[] nums, int k)
{
	var left = 0;
	var right = nums.Length - 1;

	var leftIndex = -1;
	var rightIndex = -1;
	
	while(left <= right)
	{
		var mid = (left + right)/2;
		
		if(nums[mid] == k)
		{
			leftIndex = mid;
			rightIndex = mid;
			break;
		}
		else if(nums[mid] < k)
		{
			left = mid + 1;
		}
		else if (nums[mid] > k)
		{
			right = mid - 1;
		}
	}
	
	if(leftIndex == -1 && rightIndex == -1)
	{
		return new List<int> {leftIndex, rightIndex};
	}
	
	while(leftIndex-1 >= 0 && nums[leftIndex-1] == k)
	{
		leftIndex--;
	}

	while (rightIndex+1 < nums.Length && nums[rightIndex + 1] == k)
	{
		rightIndex++;
	}
	
	return new List<int> {leftIndex, rightIndex};
}


public List<int> FindRange1(int[] nums, int k)
{
	var left = 0;
	var right = nums.Length - 1;

	var leftIndex = -1;
	var rightIndex = -1;

	while (left < right)
	{
		var mid = (left + right) / 2;
		
		if (nums[mid] < k)
		{
			left = mid + 1;
		}
		else
		{
			right = mid;
		}
	}

	leftIndex = left;
	if (leftIndex < nums.Length && nums[leftIndex] == k)
	{
		left = 0;
		right = nums.Length - 1;

		while (left < right)
		{
			var mid = (left + right + 1) / 2;

			if (nums[mid] <= k)
			{
				left = mid;
			}
			else
			{
				right = mid-1;
			}
		}
		
		return new List<int> { leftIndex, right };
	}

	return new List<int> { leftIndex, rightIndex };
}