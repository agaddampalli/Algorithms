<Query Kind="Program" />

void Main()
{
	var nums1 = new int[] { 3, 1, 2 };
	var nums2 = new int[] {1, 1 };
	
	Intersect(nums1, nums2).Dump();
}

public int[] Intersect(int[] nums1, int[] nums2)
{
	var output = new List<int>();

	Dictionary<int, int> set = new Dictionary<int, int>();
	int[] shortest = null;
	int[] longest = null;
	if (nums1.Length > nums2.Length)
	{
		longest = nums1;
		shortest = nums2;
	}
	else
	{
		shortest = nums1;
		longest = nums2;
	}
	
	for (int i = 0; i < longest.Length; i++)
	{
		if(!set.ContainsKey(longest[i]))
		{
			set.Add(longest[i], 0);
		}
		
		set[longest[i]]++;
	}
	
	for (int i = 0; i < shortest.Length; i++)
	{
		if (set.ContainsKey(shortest[i]) && set[shortest[i]] > 0)
		{
			output.Add(shortest[i]);
			set[shortest[i]]--;
		}
	}

	return output.ToArray();
}
