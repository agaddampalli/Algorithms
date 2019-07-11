<Query Kind="Program" />

void Main()
{
	PermuteUnique(new int[] {2,1,1}).Dump();
}

public List<IList<int>> output;
public IList<IList<int>> PermuteUnique(int[] nums)
{
	output = new List<IList<int>>();

	if (nums == null)
	{
		return output;
	}

	permute(nums, 0);

	return output;
}

public void permute(int[] s, int level)
{
	if (level == s.Length)
	{
		output.Add(s.ToList());
	}
	else
	{
		var hashSet = new HashSet<int>();
		for (int i = level; i < s.Length; i++)
		{
			if (!hashSet.Contains(s[i]))
			{
				swap(s, level, i);
				permute(s, level + 1);
				swap(s, level, i);
				hashSet.Add(s[i]);
			}

		}
	}
}

public void swap(int[] s, int i, int j)
{
	int temp = s[i];
	s[i] = s[j];
	s[j] = temp;
}