<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,2,1};
	
	NextGreaterElements(nums).Dump();
}

public int[] NextGreaterElements(int[] nums)
{
	var stack = new Stack<int>();
	var res = new int[nums.Length];
	for (int i = 2* nums.Length-1; i >= 0; i--)
	{
		while (stack.Any() && nums[stack.Peek()] <= nums[ i % nums.Length])
			stack.Pop();
			
		res[i % nums.Length] = !stack.Any() ? -1 : nums[stack.Peek()];
		
		stack.Push(i % nums.Length);
	}
	
	return res;
}