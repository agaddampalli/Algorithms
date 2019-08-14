<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 0, 1, 2, 4, 5, 6, 8 };

	summaryRanges(nums).Dump();
}

public List<String> summaryRanges(int[] nums)
{
	var output = new List<string>();

	var first = nums[0];
	var prev = nums[0];
	for (int i = 1; i < nums.Length; i++)
	{
		if (nums[i] != prev + 1)
		{

			if (first == prev)
			{
				output.Add($"{first}");
			}
			else
			{
				output.Add($"{first}->{prev}");
			}

			first = nums[i];
			prev = first;
		}

		prev = nums[i];
	}
	
	if (first == prev)
	{
		output.Add($"{first}");
	}
	else
	{
		output.Add($"{first}->{prev}");
	}

	return output;
}

