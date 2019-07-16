<Query Kind="Program" />

void Main()
{
	NumDecodings("20").Dump();
}

public int NumDecodings(string s)
{
	if(string.IsNullOrWhiteSpace(s) || s[0] == '0')
	{
		return 0;
	}
	
	var dp = new int[s.Length + 1];
	dp[0] = 1;
	dp[1] = IsValid(s, 0) ? 1 : 0;
	
	for (int i = 2; i <= s.Length; i++)
	{
		if(IsValid(s, i-1))
		{
			dp[i] += dp[i-1];
		}

		if (IsTwoCharacterValid(s, i - 1))
		{
			dp[i] += dp[i - 2];
		}
	}
	
	return dp[s.Length];
}


public bool IsValid(string s, int index)
{
	var ch = s[index] - '0';
	
	return ch > 0 && ch < 27;
}

public bool IsTwoCharacterValid(string s, int index)
{
	if(!IsValid(s, index-1))
	{
		return false;
	}
	
	var ch = (s[index-1] - '0') * 10 + (s[index] - '0');

	return ch > 0 && ch < 27;
}