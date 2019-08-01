<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,1,6,6};
	
	MissingNumber(nums).Dump();
}

public int MissingNumber(int[] nums)
{
	// initializations
	int min = int.MaxValue;
	int temp;
	int[] count = new int[7];

	// counting occurrences of each number in the nums array and placing in count[]
	for (int i = 0; i < nums.Length; i++)
	{
		count[nums[i]]++;
	}

count.Dump();
	// can flip each dice to any number between 1 and 6, so we find the min of each possible top face.
	for (int i = 1; i < 7; i++)
	{
		/*
		 * count twice if compliment of desired (2*count[7-desired]) +
		 * total number of dice we have (nums.length) -
		 * count of desired occurrences (count[desired] -
		 * count of compliments (count[7-desired]).
		 * simplify to:
		 */
		temp = 2 * count[7 - i] + nums.Length - count[i] - count[7 - i];
		// check if what we calculated for moves is less than something we already found.
		min = temp < min ? temp : min;
	}
	
	return min;
}