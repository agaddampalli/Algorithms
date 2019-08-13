<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 2, 1, 4, 3, 2, 5 };

	HasDuplicates(nums).Dump();

}

public int HasDuplicates(int[] nums)
{

	var slow = nums[0];
	var fast = nums[0];

	do
	{
		slow = nums[slow];
		fast = nums[nums[fast]];
	} while (fast != slow);

	var pntr1 = nums[0];
	var pntr2 = slow;

	for (int i = 0; i < nums.Length; i++)
	{
		if (nums[i] == pntr2)
		{
			pntr1 = nums[i];
			break;
		}
	}

	return pntr1;
}
