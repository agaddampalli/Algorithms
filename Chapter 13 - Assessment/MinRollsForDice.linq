<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,2,3,4,5};
	
	MinRollsForDice(nums).Dump();
}

public int MinRollsForDice(int[] nums)
{
	var counts = new int[7];
	
	for (int i = 0; i < nums.Length; i++)
	{
		counts[nums[i]]++;
	}
	
	var min = int.MaxValue;
	for (int i = 1; i < 7; i++)
	{
		var complimentNumberCount = 2 * counts[7-i];
		
		var temp = (complimentNumberCount + nums.Length) - counts[i] - counts[7-i];
		
		min = temp < min ? temp : min;
	}
	
	return min;
}
