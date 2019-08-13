<Query Kind="Program" />

void Main()
{
	var nums = new int[] {3, 30, 34, 5, 9 };

	LargestNumber(nums).Dump();
	LargestNumber1(nums).Dump();
}

public string maxNumber = null;
public string LargestNumber(int[] nums)
{
	if(nums == null || nums.Length == 0)
	{
		return string.Empty;
	}
	
	var output = new int[nums.Length];
	
	BackTrack(new List<int>(nums), string.Empty, 0, nums.Length);
	
	return maxNumber;
}

public void BackTrack(List<int> nums, string num, int index , int length)
{
	if(index == length && num.CompareTo(maxNumber) == 1)
	{
		maxNumber = num;
		return;
	}
	
	for (int i = 0; i < nums.Count; i++)
	{
		var temp = nums[i];
		nums.RemoveAt(i);
		BackTrack(nums, num + temp, index+1, length);
		nums.Insert(i, temp);
	}
}


public string LargestNumber1(int[] nums)
{
	if (nums == null || nums.Length == 0)
	{
		return string.Empty;
	}

	Array.Sort(nums, (x,y) => (y.ToString() + x.ToString()).CompareTo(x.ToString() + y.ToString()));
	
	var output = new StringBuilder();
	
	for (int i = 0; i < nums.Length; i++)
	{
		output.Append(nums[i]);
	}

	while(output[0] == '0' && output.Length > 1)
	{
		output.Remove(0,1);
	}
	
	return output.ToString();
}