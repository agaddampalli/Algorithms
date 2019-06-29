<Query Kind="Program" />

void Main()
{
	var nums = new int[] {4,1,2,1,2};
	
	SingleNumber(nums).Dump();
}

public int SingleNumber(int[] nums)
{
//	var hashSet = new HashSet<int>();
//	
//	for (int i = 0; i < nums.Length; i++)
//	{
//		if(hashSet.Contains(nums[i]))
//		{
//			hashSet.Remove(nums[i]);
//			continue;
//		}
//		
//		hashSet.Add(nums[i]);
//	}
//	
//	return hashSet.FirstOrDefault();

	int result = 0;

	for (int i = 0; i < nums.Length; i++)
	{
		result ^= nums[i];
	}

	return result;
}