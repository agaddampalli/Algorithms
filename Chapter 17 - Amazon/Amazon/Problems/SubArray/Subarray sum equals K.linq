<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 2, 3, 4, 5, -6, 11 };

	SubarraySum(input, 5).Dump();
	SubarraySumBruteForce(input, 5).Dump();
	SubarraySumArrays(input,5).Dump();
}

public int SubarraySum(int[] nums, int k)
{
	int count = 0;
	
	var dict = new Dictionary<int, int>();
	dict.Add(0, 1);
	
	var sum = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		sum += nums[i];
		if(dict.ContainsKey(sum - k))
		{
			count += dict[sum-k];
		}
		
		if(!dict.ContainsKey(sum))
		{
			dict.Add(sum, 0);
		}
		
		dict[sum]++;
	}
	
	return count;
}


public int SubarraySumBruteForce(int[] nums, int k)
{
	int count = 0;

	for (int i = 0; i < nums.Length; i++)
	{
		var sum = 0;
		for (int j = i; j < nums.Length; j++)
		{
			sum += nums[j];
			if(sum == k)
			{
				count++;
			}
		}
	}

	return count;
}

public List<IList<int>> SubarraySumArrays(int[] nums, int k)
{
	var output = new List<IList<int>>();

	var dict = new Dictionary<int, int>();
	dict.Add(0, 1);

	var sum = 0;
	for (int i = 0; i < nums.Length; i++)
	{
		sum += nums[i];
		if (dict.ContainsKey(sum - k))
		{
			output.Add(new List<int> {dict[sum - k], i});
		}

		if (!dict.ContainsKey(sum))
		{
			dict.Add(sum, i+1);
		}
	}

	return output;
}