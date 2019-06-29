<Query Kind="Program" />

void Main()
{
	
}

public List<int> MajorityElement(int[] nums)
{
	if (nums == null || nums.Length == 0)
		return new List<int>();
	List<int> result = new List<int>();
	int number1 = nums[0], number2 = nums[0], count1 = 0, count2 = 0, len = nums.Length;
	for (int i = 0; i < len; i++)
	{
		if (nums[i] == number1)
			count1++;
		else if (nums[i] == number2)
			count2++;
		else if (count1 == 0)
		{
			number1 = nums[i];
			count1 = 1;
		}
		else if (count2 == 0)
		{
			number2 = nums[i];
			count2 = 1;
		}
		else
		{
			count1--;
			count2--;
		}
	}
	count1 = 0;
	count2 = 0;
	for (int i = 0; i < len; i++)
	{
		if (nums[i] == number1)
			count1++;
		else if (nums[i] == number2)
			count2++;
	}
	if (count1 > len / 3)
		result.Add(number1);
	if (count2 > len / 3)
		result.Add(number2);
	return result;
}
