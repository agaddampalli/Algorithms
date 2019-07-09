<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,2,3,4,5,6,7};
	Rotate(nums,3);
}

public void Rotate(int[] nums, int k)
{

	if (nums == null || nums.Length == 0)
		return;
	k = k % nums.Length;
	reverse(nums, 0, nums.Length - 1);
	reverse(nums, 0, k - 1);
	reverse(nums, k, nums.Length - 1);
}

private static void reverse(int[] nums, int start, int end)
{
	while (start < end)
	{
		int temp = nums[start];
		nums[start] = nums[end];
		nums[end] = temp;
		start++;
		end--;
	}
}