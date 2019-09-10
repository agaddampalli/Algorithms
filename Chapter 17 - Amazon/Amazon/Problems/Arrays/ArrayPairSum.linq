<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,2,3,4,5,6};
	
	ArrayPairSum(nums).Dump();
}

public int ArrayPairSum(int[] nums)
{
	var bucket = new int[20001];
	foreach (var num in nums)
		bucket[num + 10000]++;

	var odd = true;
	var total = 0;
	for (var i = 0; i < bucket.Length;)
	{
		if (bucket[i] > 0)
		{
			if (odd)
				total += i - 10000;
			odd = !odd;
			bucket[i]--;
		}
		else
			i++;
	}
	
	return total;
}