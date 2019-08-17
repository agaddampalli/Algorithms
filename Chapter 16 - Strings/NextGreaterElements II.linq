<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 3, 1, 2, 4 };

	NextGreaterElements(nums).Dump();
	NextGreaterElements1(nums).Dump();
}

public int[] NextGreaterElements(int[] nums)
{
	var stack = new Stack<int>();
	var res = new int[nums.Length];
	for (int i = 2 * nums.Length - 1; i >= 0; i--)
	{
		while (stack.Any() && nums[stack.Peek()] <= nums[i % nums.Length])
			stack.Pop();

		res[i % nums.Length] = !stack.Any() ? -1 : nums[stack.Peek()];

		stack.Push(i % nums.Length);
	}

	return res;
}

public int[] NextGreaterElements1(int[] nums)
{
	var dict = new Dictionary<int, int>();
	var stack = new Stack<int>();

	var temp = new int[2 * nums.Length];

	Array.Copy(nums, temp, nums.Length);
	Array.Copy(nums, 0, temp, nums.Length, nums.Length);

	var output = new int[nums.Length];
	for (int i = 0; i < temp.Length; i++)
	{
		while (stack.Any() && temp[i] > stack.Peek())
		{
			var val = stack.Pop();
			if (!dict.ContainsKey(val))
			{
				dict.Add(val, temp[i]);
			}
			else
			{
				dict[val] = temp[i];
			}

		}

		stack.Push(temp[i]);
	}

	while (stack.Count != 0)
	{
		var val = stack.Pop();
		if (!dict.ContainsKey(val))
		{
			dict.Add(val, -1);
		}
	}

	for (int i = 0; i < nums.Length; i++)
	{
		output[i] = dict[nums[i]];
	}

	return output;
}

public int[] NextGreaterElements2(int[] T)
{
	Stack<int> st = new Stack<int>();
	int[] res = new int[T.Length];
	for (int i = 0; i < T.Length; i++)
	{
		res[i] = -1;
	}
	for (int i = 0; i < 2 * T.Length; i++)
	{
		int num = T[i % T.Length]; ;
		while (st.Count > 0 && num > T[st.Peek() % T.Length])
		{
			int top = st.Pop();
			res[top % T.Length] = num;
		}
		st.Push(i);
	}

	return res;
}