<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 1,-9,8,-6,6,4,0,5};

	MaxSlidingWindow(nums, 4).Dump();
	MaxSlidingWindowDequeue(nums, 4).Dump();
}

public int[] MaxSlidingWindow(int[] nums, int k)
{
	var output = new List<int>();
	
	for (int i = 0; i + k-1 < nums.Length; i++)
	{
		var max = int.MinValue;
		for (int j = i; j-i < k; j++)
		{
			if(nums[j] >= max)
			{
				max = nums[j];
			}
		}
		
		output.Add(max);
	}
	
	return output.ToArray();
}

public int[] MaxSlidingWindowDequeue(int[] nums, int k)
{
	if (nums == null || nums.Length * k == 0)
	{
		return new int[0];
	}

	if (k == 1)
	{
		return nums;
	}
	
	var queue = new List<int>();
	
	var max = int.MinValue;
	for (int i = 0; i < k; i++)
	{
		CleanQueue(nums, i, k, queue);
		queue.Add(i);
		max = Math.Max(max, nums[i]);
	}
	
	var output = new int[nums.Length - k + 1];
	output[0] = max;
	
	for (int i = k; i  < nums.Length; i++)
	{
		CleanQueue(nums, i, k, queue);
		
		queue.Add(i);
		
		output[i-k+1] = nums[queue.First()];
	}

	return output;
}

public void CleanQueue(int[] nums, int i, int k, List<int> queue)
{
	while(queue.Any() && queue.First() == i-k)
	{
		queue.RemoveAt(0);
	}

	while (queue.Any() && nums[queue.Last()] <= nums[i])
	{
		queue.RemoveAt(queue.Count-1);
	}
}