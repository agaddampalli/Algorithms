<Query Kind="Program" />

void Main()
{
	var nums = new int[] {3,4,5,1,2};
	
	FindKthLargestNumber(nums,1).Dump();
}

public int FindKthLargestNumber(int[] nums, int k)
{
	Sort(nums, 0, nums.Length-1, k);
	
	return nums[k-1];
}


private static void Sort(int[] nums, int left, int right, int k)
{
	if(left <= right)
	{
		var pivot = GetPivot(nums, left, right);
		
		if(pivot == k)
		{
			return;
		}
		else if(pivot < k)
		{
			Sort(nums, pivot+1, right, k);
		}
		else if(pivot > k)
		{
			Sort(nums, left, pivot-1, k);
		}
	}
	
	return;
}

private static int GetPivot(int[] nums, int left, int right)
{
	var pivot = nums[left];
	var index = left;
	for (int i = left+1; i <= right; i++)
	{
		if(pivot < nums[i])
		{
			index++;
			Swap(nums, index, i);
		}
	}
	
	Swap(nums, left, index);
	
	return index;
}

private static void Swap(int[] nums, int i , int j)
{
	var temp = nums[i];
	nums[i] = nums[j];
	nums[j] = temp;
}