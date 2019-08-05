<Query Kind="Program" />

void Main()
{
	var s = "abba";
	CountPalindromicSubstrings(s).Dump();
}

public int CountPalindromicSubstrings(string s)
{
	if(string.IsNullOrWhiteSpace(s))
	{
		return 0;
	}
	
	var dp = new bool[s.Length, s.Length];
	
	int count = 0;
	for (int i = 0; i < s.Length; i++)
	{
		dp[i,i] = true;
		count++;
	}
	
	for (int i = 1; i < s.Length; i++)
	{
		if (s[i - 1] == s[i])
		{
			dp[i-1, i] = true;
			count++;
		}
	}
	
	for (int k = 2; k < s.Length; k++)
	{
		for (int j = k; j < s.Length; j++)
		{
			var i = j-k;
			
			if(s[i] == s[j] && dp[i+1, j-1])
			{
				dp[i, j] = true;
				count++;
			}
		}
	}
	
	return count;
}
