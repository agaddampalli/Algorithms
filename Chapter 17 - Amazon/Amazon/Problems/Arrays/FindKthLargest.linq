<Query Kind="Program" />

void Main()
{
	var nums = new int[] {3,2,3,1,2,4,5,5,6};
	
	FindKthLargest(nums, 4).Dump();
}

public int FindKthLargest(int[] nums, int k)
{
	Sort(nums, k, 0, nums.Length-1);
	
	var min = int.MaxValue;
	
	for (int i = 0; i < k; i++)
	{
		min = Math.Min(min, nums[i]);
	}
	
	return min;
}


// 6 5 4 2 1 3

public void Sort(int[] nums, int k, int left, int right)
{
	if(left > right)
	{
		return;
	}
	
	var pivot = FindPivot(nums, left, right);
	
	if(pivot == k-1)
	{
		return;
	}
	else if( pivot < k-1)
	{
		left = pivot + 1;
		Sort(nums, k, left, right);
	}
	else
	{
		right = pivot-1;
		Sort(nums, k, left, right);
	}
}


public int FindPivot(int[] nums, int left, int right)
{
	//	var pivot = nums[right];
	//	var index = right;
	//	
	//	for (int i = right-1; i >= left; i--)
	//	{
	//		if(pivot > nums[i])
	//		{
	//			index--;
	//			Swap(nums, index, i);
	//		}
	//	}
	//	
	//	Swap(nums, index, right);
	//	
	//	return index;

	var pivot = nums[left];
	var index = left;

	for (int i = left+1; i <= right; i++)
	{
		if (pivot < nums[i])
		{
			index++;
			Swap(nums, index, i);
		}
	}

	Swap(nums, index, left);

	return index;
}

public void Swap(int[] nums, int i, int j)
{
	var temp = nums[i];
	nums[i] = nums[j];
	nums[j] = temp;
}
