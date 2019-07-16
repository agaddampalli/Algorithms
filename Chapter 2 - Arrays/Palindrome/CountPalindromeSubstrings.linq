<Query Kind="Program" />

void Main()
{
	CountSubstrings("aaa").Dump();
}

public int CountSubstrings(string s)
{
	bool[,] dp = new bool[s.Length, s.Length];
	
	var count  = 0;
	var output = new List<string>();
	
	for (int i = 0; i < s.Length; i++)
	{
		dp[i, i] = true;
		output.Add(s[i].ToString());
		count++;
	}

	for (int i = 0; i < s.Length - 1; i++)
	{
		if (s[i] == s[i + 1])
		{
			dp[i, i + 1] = true;
			output.Add(s[i].ToString() + s[i+1].ToString());
			count++;
		}
	}

	for (int i = 2; i < s.Length; i++)
	{
		for (int j = 0; j + i < s.Length; j++)
		{
			var k = i + j;

			if (s[j] == s[k] && dp[j + 1, k - 1])
			{
				dp[j, k] = true;
				output.Add(s.Substring(j, i+1));
				count++;
			}
		}
	}

	output.Dump();
	return count;
}
