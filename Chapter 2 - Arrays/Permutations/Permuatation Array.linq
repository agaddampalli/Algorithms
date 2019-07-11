<Query Kind="Program" />

void Main()
{
	var s = "abcd";
	
//	permute(s.ToCharArray(), 0);
	
	var input = new int[]{2,1,1};
	
	Permute(input).Dump();
}

public void permute(char[] s, int l)
{
	if (l == s.Length)
	{
		var temp = new String(s);
		temp.Dump();
	}
	else
	{
		for (int i = l; i < s.Length; i++)
		{
			if (s[i] != s[l] && i != l)
			{
				swap(s, l, i);
				permute(s, l + 1);
				swap(s, l, i);
			}
		}
	}
}

public void swap(char[] s, int i, int j)
{
	char temp = s[i];
	s[i] = s[j];
	s[j] = temp;
}

public List<IList<int>> output;
public IList<IList<int>> Permute(int[] nums)
{
	output = new List<IList<int>>();

	if (nums == null)
	{
		return output;
	}

	permute(nums, 0);

	return output;
}

public void permute(int[] s, int l)
{
	if (l == s.Length)
	{
		output.Add(s.ToList());
	}
	else
	{
		for (int i = l; i < s.Length; i++)
		{
			swap(s, l, i);
			permute(s, l + 1);
			swap(s, l, i);
		}
	}
}

public void swap(int[] s, int i, int j)
{
	int temp = s[i];
	s[i] = s[j];
	s[j] = temp;
}