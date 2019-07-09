<Query Kind="Program" />

void Main()
{
	var input = new int[] { 64, 34, 25, 12, 22, 11, 90 };

	Merge(input);
}

//Worst Time Complexity : O(nlogn) 
// Space Complexity: O(n)
public void Merge(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return;
	}
	
	Sort(nums, 0, nums.Length-1);
	
	nums.Dump();
}

private static void Sort(int[] nums, int l, int r)
{
	if (l < r)
	{
		var m = (l + r) / 2;

		Sort(nums, l, m);

		Sort(nums, m + 1, r);

		Merge(nums, l, m, r);
	}
}

private static void Merge(int[] nums, int l, int m, int r)
{
	var left = new int[m - l + 1];
	var right = new int[r - m];

	Array.Copy(nums, l, left, 0, m - l + 1);
	Array.Copy(nums, m + 1, right, 0, r - m);

	int x = 0;
	int y = 0;
	for (int i = l; i <= r ; i++)
	{
		if (x >= right.Length)
		{
			nums[i] = left[y];
			y++;
		}
		else if (y >= left.Length)
		{
			nums[i] = right[x];
			x++;
		}
		else if (right[x] < left[y])
		{
			nums[i] = right[x];
			x++;
		}
		else
		{
			nums[i] = left[y];
			y++;
		}
	}
}