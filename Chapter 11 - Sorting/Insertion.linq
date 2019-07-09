<Query Kind="Program" />

void Main()
{
	var input = new int[] { 64, 34, 25, 12, 22, 11, 90 };

	Insertion(input);
}

//Worst Time Complexity : O(n2) 
// Space Complexity: O(1)
public void Insertion(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return;
	}
	
	nums.Dump();
	
	for (int i = 1; i < nums.Length; i++)
	{
		int j = i;
		while (j > 0 && nums[j] < nums[j - 1])
		{
			Swap(j, j - 1, nums);
			j--;
		}
	}
	
	
	nums.Dump();
}

public void Swap(int i, int j, int[] nums)
{
	var temp = nums[j];
	nums[j] = nums[i];
	nums[i] = temp;
}