<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,2};
	
	TopKFrequent(nums, 2).Dump();
}

public Dictionary<int, int> dict;
public IList<int> TopKFrequent(int[] nums, int k)
{
	var output = new HashSet<int>();

	if (nums == null || k == 0)
	{
		return output.ToList();
	}
	
	dict = new Dictionary<int, int>();
	var uniqueElementsList = new List<int>();
	for (int i = 0; i < nums.Length; i++)
	{
		if(!dict.ContainsKey(nums[i]))
		{
			dict.Add(nums[i], 0);
			uniqueElementsList.Add(nums[i]);
		}
		
		dict[nums[i]]++;
	}
	
	Sort(uniqueElementsList, k, 0, uniqueElementsList.Count -1);
	
	for (int i = 0; i < k; i++)
	{
		output.Add(uniqueElementsList[i]);
	}
	
	return output.ToList();
}

public void Sort(List<int> nums, int k, int left, int right)
{
	if (left > right)
	{
		return;
	}

	var pivot = FindPivot(nums, left, right);

	if (pivot == k - 1)
	{
		return;
	}
	else if (pivot < k - 1)
	{
		left = pivot + 1;
		Sort(nums, k, left, right);
	}
	else
	{
		right = pivot - 1;
		Sort(nums, k, left, right);
	}
}


public int FindPivot(List<int> nums, int left, int right)
{
	var pivot = nums[left];
	var index = left;

	for (int i = left + 1; i <= right; i++)
	{
		if (dict[pivot] < dict[nums[i]])
		{
			index++;
			Swap(nums, index, i);
		}
	}

	Swap(nums, index, left);

	return index;
}

public void Swap(List<int> nums, int i, int j)
{
	var temp = nums[i];
	nums[i] = nums[j];
	nums[j] = temp;
}