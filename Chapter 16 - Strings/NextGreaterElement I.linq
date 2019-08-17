<Query Kind="Program" />

void Main()
{
	var nums1 = new int[] { 4,1,2 };
	var nums2 = new int[] { 1, 3, 4, 2 , 5 };

	NextGreaterElement1(nums1, nums2).Dump();
}

public int[] NextGreaterElement(int[] nums1, int[] nums2)
{
	var dict = new Dictionary<int, int>();

	for (int i = 0; i < nums2.Length; i++)
	{
		dict.Add(nums2[i], i);
	}

	var output = new int[nums1.Length];
	for (int i = 0; i < nums1.Length; i++)
	{
		var index = dict[nums1[i]];
		output[i] = -1;
		for (int j = index; j < nums2.Length; j++)
		{
			if (nums1[i] < nums2[j])
			{
				output[i] = nums2[j];
				break;
			}
		}
	}

	return output;
}

public int[] NextGreaterElement1(int[] nums1, int[] nums2)
{
	var stack = new Stack<int>();
	var map = new Dictionary<int, int>();
	var res = new int[nums1.Length];
	for (int i = 0; i < nums2.Length; i++)
	{
		while (stack.Any() && nums2[i] > stack.Peek())
			map.Add(stack.Pop(), nums2[i]);
		stack.Push(nums2[i]);
	}
	while (stack.Any())
		map.Add(stack.Pop(), -1);
	for (int i = 0; i < nums1.Length; i++)
	{
		res[i] = map[nums1[i]];
	}
	return res;
}