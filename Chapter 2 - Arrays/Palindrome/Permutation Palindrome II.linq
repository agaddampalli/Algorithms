<Query Kind="Program" />

void Main()
{
	GeneratePalindromes1("aabbhijkkjih").Dump();
}

HashSet<string> output;
public IList<string> GeneratePalindromes(string s)
{
	output = new HashSet<string>();

	var input = new int[128];

	for (int i = 0; i < s.Length; i++)
	{
		input[s[i]]++;
	}
	
	if (string.IsNullOrWhiteSpace(s) || !CanPermutePalindrome(input))
	{
		return output.ToList();
	}
	
	FindPermutationStrings(s, "");
	
	return output.ToList();
}

public IList<string> GeneratePalindromes1(string s)
{
	output = new HashSet<string>();

	var input = new int[128];

	for (int i = 0; i < s.Length; i++)
	{
		input[s[i]]++;
	}
	
	if (string.IsNullOrWhiteSpace(s) || !CanPermutePalindrome(input))
	{
		return output.ToList();
	}

	var temp = string.Empty;
	char ch = (char)0;

	for (int i = 0; i < input.Length; i++)
	{
		if(input[i] % 2 == 1)
		{
			ch = s[i];
		}

		var res = input[i] / 2;
		for (int j = 0; j < res; j++)
		{
			temp = temp + (char)i;
		}
	}
	
	permute(temp.ToCharArray(), 0, ch);

	return output.ToList();
}

public void FindPermutationStrings(string s, string prefix, char ch)
{
	if (string.IsNullOrWhiteSpace(s))
	{
		var reverse =  prefix.Reverse().ToArray();
		var res = prefix + (ch == 0 ? "" : ch.ToString()) + new String(reverse);
		
		if(!output.Contains(res))
		{
			output.Add(res);
		}
	}

	for (int i = 0; i < s.Length; i++)
	{
		var temp = s.Substring(i, 1);
		var rem = s.Substring(0, i) + s.Substring(i + 1);

		FindPermutationStrings(rem, prefix + temp, ch);
	}
}

public void FindPermutationStrings(string s, string prefix)
{
	if(string.IsNullOrWhiteSpace(s) && IsPalindrome(prefix) && !output.Contains(prefix))
	{
		output.Add(prefix);
	}
	
	for (int i = 0; i < s.Length; i++)
	{
		var temp = s.Substring(i, 1);
		var rem = s.Substring(0,i)+ s.Substring(i+1);
		
		FindPermutationStrings(rem, prefix + temp);
	}
}


public void permute(char[] s, int l, char ch)
{
	if (l == s.Length)
	{
		var res = new String(s) + (ch == 0 ? "" : ch.ToString()) + new String(s.Reverse().ToArray());
		if (!output.Contains(res))
		{
			output.Add(res);
		}
	}
	else
	{
		for (int i = l; i < s.Length; i++)
		{
			if (s[l] != s[i] || l == i)
			{
				swap(s, l, i);
				permute(s, l + 1, ch);
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

public bool CanPermutePalindrome(int[] input)
{
		int count = 0;
	for (int i = 0; i < input.Length; i++)
	{
		if (input[i] % 2 == 1)
		{
			count++;
		}

		if (count > 1)
		{
			return false;
		}
	}

	return true;
}

public bool IsPalindrome(string s)
{
	int i = 0;
	int j = s.Length - 1;

	while (i < j)
	{
		if (s[i] != s[j])
		{
			return false;
		}

		i++;
		j--;
	}

	return true;
}