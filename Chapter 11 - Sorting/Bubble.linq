<Query Kind="Program" />

void Main()
{
	var input = new int[] { 64, 34, 25, 12, 22, 11, 90 };

	Bubble(input);
}

//Worst Time Complexity : O(n2) 
// Space Complexity: O(1)
public void Bubble(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return;
	}
	
	nums.Dump();
	
	bool isSwapped = false;
	int i = 1;
	int j = 0;
	while(true)
	{
		if(nums[i] < nums[i-1])
		{
			Swap(i, i-1, nums);
			isSwapped = true;
		}
		
		i++;
		
		if(!isSwapped && i >= nums.Length)
		{
			break;
		}
		
		if(i >= nums.Length)
		{
			i = 1;
			isSwapped = false;
			j++;
		}
	}

	$"number of times looped : {j}".Dump();
	nums.Dump();
}

public void Swap(int i, int j, int[] nums)
{
	var temp = nums[j];
	nums[j] = nums[i];
	nums[i] = temp;
}