<Query Kind="Program" />

void Main()
{
	var input = new int[] {0,2,1};
	MissingNumber(input).Dump();
}

public int MissingNumber(int[] nums)
{
	if(nums == null)
	{
		return 0;
	}
	
	var length = nums.Length;
	
	var formulaSum = (length * (length + 1))/2;
	int sum = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		sum += nums[i];
	}
	
	return formulaSum - sum;
}
