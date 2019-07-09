<Query Kind="Program" />

void Main()
{
	var input = new int[] { 64, 25, 12, 22, 11};
	
	Selection(input);
}

//Time Complexity : O(n2) 
// Space Complexity: O(1)
public void Selection(int[] nums)
{
	if(nums == null || nums.Length == 0)
	{
		return;
	}
	
	nums.Dump();
	
	for (int i = 0; i < nums.Length; i++)
	{
		var min = i;
		for (int j = i+1; j < nums.Length; j++)
		{
			if(nums[j] < nums[min])
			{
				min = j;
			}
		}
		
		var temp = nums[i];
		nums[i] = nums[min];
		nums[min] = temp;
	}
	
	nums.Dump();
}