<Query Kind="Program" />

void Main()
{
	LongestPalindromeDP("abaaaa").Dump();
	LongestPalindromeMiddleout("abaaaa").Dump();
}

public string LongestPalindromeDP(string s)
{

	bool[,] dp = new bool[s.Length, s.Length];

	var maxLength = 1;
	var startIndex = 0;
	for (int i = 0; i < s.Length; i++)
	{
		dp[i,i] = true;
	}

	for (int i = 0; i < s.Length-1; i++)
	{
		if(s[i] == s[i+1])
		{
			dp[i, i+1] = true;
			maxLength = 2;
			startIndex = i;
		}
	}
	
	for (int i = 2; i < s.Length; i++)
	{
		for (int j = 0; j + i < s.Length; j++)
		{
			var k = i+j;
			
			if(s[j] == s[k] && dp[j+1, k-1])
			{
				dp[j, k] = true;
				
				if(i >= maxLength)
				{
					maxLength = i + 1;
					startIndex = j;
				}
			}
		}
	}
	
	return s.Substring(startIndex, maxLength);
}


public string LongestPalindromeMiddleout(string s)
{
	var maxLength = int.MinValue;
	var startIndex = 0;

	for (int i = 0; i < s.Length; i++)
	{
		var len1 = ExpandAroundCenter(s, i, i);
		var len2 = ExpandAroundCenter(s, i, i+1);
		
		var len = len1 > len2 ? len1 : len2;
		
		if(len >= maxLength)
		{
			maxLength = len;
			startIndex = i - (len -1)/2;
		}
	}

	return s.Substring(startIndex, maxLength);
}

public int ExpandAroundCenter(string s, int left, int right)
{
	while(left >= 0 && right < s.Length && s[left] == s[right])
	{
		left--;
		right++;
	}
	
	return right - left -1;
}
public string LongestPalindromeBruteForce(string s)
{
	var maxLength = int.MinValue;
	var maxWord = string.Empty;
	
	for (int i = 0; i < s.Length; i++)
	{
		for (int j = i; j <= s.Length; j++)
		{
			var temp = s.Substring(i, j-i);
			
			if(IsPalindrome(s) && temp.Length > maxLength)
			{
				maxLength = temp.Length;
				maxWord = temp;
			}
		}
	}
	
	return maxWord;
}

public bool IsPalindrome(string s)
{
	int i = 0;
	int j = s.Length-1;
	
	while(i < j)
	{
		if(s[i] != s[j])
		{
			return false;
		}
		
		i++;
		j--;
	}
	
	return true;
}
