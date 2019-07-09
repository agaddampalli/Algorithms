<Query Kind="Program" />

void Main()
{
	var input = new int[] {1,2,0};

	SortColors(input);
	
	input.Dump();
}

public void SortColors(int[] nums)
{
	
	var x = 0;
	var y = nums.Length -1;
	
	for (int i = 0; i < nums.Length && i <= y; i++)
	{
		if(nums[i] == 0)
		{
			var temp = nums[x];
			nums[x] = nums[i];
			nums[i] = temp;
			x++;
		}
		
		if(nums[i] == 2)
		{
			var temp = nums[y];
			nums[y] = nums[i];
			nums[i] = temp;
			y--;
			i--;
		}
	}
}