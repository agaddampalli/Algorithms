<Query Kind="Program" />

void Main()
{
	LongestPalindromeBruteForce("cbbd").Dump();
}

public string LongestPalindromeBruteForce(string s)
{
	var maxLength = int.MinValue;
	var maxString = string.Empty;
	
	for (int i = 0; i < s.Length; i++)
	{
		for (int j = i; j <= s.Length; j++)
		{
			var temp = s.Substring(i, j-i);
			
			if(IsPalindrome(temp) && temp.Length > maxLength)
			{
				maxLength = temp.Length;
				maxString = temp;
			}
		}
	}
	
	return maxString;
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