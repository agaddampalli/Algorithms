<Query Kind="Program" />

void Main()
{
	var input = new int[] { 2, 0, -1, 0, 0, 2, -1 };

	MaxLengthSumToTargetSlow(input, 3).Dump();
	MaxLengthSumToTarget(input, 0).Dump();

	// 2 2 1 1 1 3 2
	
	// -1 -2 1 3 5
}

public int MaxLengthSumToTarget(int[] nums, int k)
{	
	int maxLength = 0, sum = 0;
	var sumDictionary = new Dictionary<int, int>();
	
	for (int i = 0; i < nums.Length; i++)
	{
		sum = sum + nums[i];
		if(sum == k)
		{
			maxLength = i+1;
		}
		else if(sumDictionary.ContainsKey(sum - k))
		{
			maxLength = Math.Max(maxLength, i - sumDictionary[sum - k]);
		}
		
		if(!sumDictionary.ContainsKey(sum))
		{
			sumDictionary.Add(sum,i);
		}
	}

	return maxLength;
}

public int MaxLengthSumToTargetSlow(int[] nums, int target)
{
	if (nums.Length == 0)
	{
		return 0;
	}

	int maxLength = 0;

	for (int i = 0; i < nums.Length; i++)
	{
		var sum = nums[i];
		if (sum == target)
		{
			maxLength = maxLength > 1 ? maxLength : 1;
		}
		for (int j = i + 1; j < nums.Length; j++)
		{
			sum = sum + nums[j];
			if (sum == target)
			{
				maxLength = maxLength > j - i + 1 ? maxLength : j - i + 1;
			}
		}
	}


	return maxLength;
}
