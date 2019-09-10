<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1, 0, 1,1,0,1};
	
	FindMaxConsecutiveOnes(nums).Dump();
}


public int FindMaxConsecutiveOnes(int[] nums)
{
	int i = 0, j = 0;
	
	int maxLength = int.MinValue;
	
	while(j < nums.Length)
	{
		if(nums[j] != 1)
		{
			maxLength = Math.Max(maxLength, j-i);
			i = j + 1;
		}
		
		j++;
	}
	
	maxLength = Math.Max(maxLength, j-i);
	
	return maxLength;
}