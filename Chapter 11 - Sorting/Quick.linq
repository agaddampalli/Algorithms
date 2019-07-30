<Query Kind="Program" />

void Main()
{
	var input = new int[] { 64, 34, 25, 12, 80, 11, 90 };

	Quick(input);
}

//Worst Time Complexity : O(n2) - already sorted array , O(nlogn) 
// Space Complexity: O(1)
public void Quick(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return;
	}

	Sort(nums, 0, nums.Length - 1);

	nums.Dump();
}

public void Sort(int[] nums, int low, int high)
{
	if(low < high)
	{
		var pivot = PartitionFirst(nums, low, high);
		
		Sort(nums, low, pivot-1);
		Sort(nums, pivot+1, high);
	}
}

public int PartitionLast(int[] nums, int low, int high)
{
	var pivot = nums[high];
	int start = low;

	for (int i = low ; i < high; i++)
	{
		if(nums[i] < pivot)
		{
			Swap(start, i, nums);
			start++;
		}
	}
	
	Swap(start, high, nums);
	return start;
}

public int PartitionFirst(int[] nums, int low, int high)
{
	var pivot = nums[low];
	int start = low;
	
	for (int i = low + 1; i <= high; i++)
	{
		if (nums[i] <= pivot)
		{
			start++;
			Swap(start, i, nums);
		}
	}

	Swap(start, low, nums);
	return start;
}

public int PartitionMiddle(int[] nums, int low, int high)
{
	var mid = (low+high)/2;
	var pivot = nums[mid];
	int start = low;
	int end = high;
	
	while (start < end)
	{
		if (nums[start] >= pivot && nums[end] <= pivot)
		{
			Swap(start, end, nums);
			start++;
			end--;
		}
		else if(nums[start] < pivot)
		{
			start++;
		}
		else if (nums[end] > pivot){
			end--;
		}
	}

	return mid;
}


public void Swap(int i, int j, int[] nums)
{
	var temp = nums[j];
	nums[j] = nums[i];
	nums[i] = temp;
}