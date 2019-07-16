<Query Kind="Program" />

void Main()
{
	LongestPalindromeSubseq("bbbab").Dump();
	LongestPalindromeSubseqBruteForce("cbbd").Dump();
	LongestPalindromeSubseqDP("bbbab").Dump();
}

public int LongestPalindromeSubseq(string s)
{
	return GeneratePalindromes(s);
}

public int LongestPalindromeSubseqDP(string s)
{
	int[,] dp = new int[s.Length, s.Length];
	
	for (int i = 0; i < s.Length; i++)
	{
		dp[i,i] = 1;
	}

	for (int k = 1; k < s.Length; k++)
	{
		for (int i = 0; i + k < s.Length; i++)
		{
			var j = k+i;
			
			if(s[i] == s[j])
			{
				dp[i,j] = 2 + dp[i+1, j-1];
			}
			else
			{
				dp[i,j] = Math.Max(dp[i, j-1], dp[i+1,j]);
			}
		}
	}

	dp.Dump();
	
	var length = dp[0, s.Length -1];
	var lcs = new char[length]; 
	
	int x = 0, y = s.Length-1;
	var index = 0;
	
	while(x < y)
	{
		if(dp[x, y-1] == dp[x+1,y])
		{
			if(dp[x, y] > 1)
			{
				lcs[index] = s[x];
				lcs[lcs.Length-index-1] = s[y];
				
				x++;
				y--;
			}
			else
			{
				lcs[index] = s[x];
			}
			
			index++;
		}
		else if(dp[x, y] == dp[x, y-1])
		{
			y--;
		}
		else if(dp[x, y] == dp[x+1, y])
		{
			x++;
		}
	}


	if (x == y)
	{
		lcs[index] = s[x];
	}
	
	var temp = new String(lcs);
	temp.Dump();
	return dp[0,s.Length-1];
}

public int LongestPalindromeSubseqBruteForce(string s)
{
	var maxLength = int.MinValue;
	var maxWord = string.Empty;
	
	for (int i = 0; i < s.Length; i++)
	{
		for (int j = i; j < s.Length; j++)
		{
			var temp = s.Substring(i, j-i) + s.Substring(j+1);
			
			if(IsPalindrome(temp) && temp.Length > maxLength)
			{
				maxLength = temp.Length;
				maxWord = temp;
			}
		}
	}
	
	maxWord.Dump();
	return maxLength;
}

public int MaxLength = int.MinValue;
public string MaxWord = null;

public int GeneratePalindromes(string s)
{
	var input = new int[128];

	for (int i = 0; i < s.Length; i++)
	{
		input[s[i]]++;
	}

	if (string.IsNullOrWhiteSpace(s) || !CanPermutePalindrome(input))
	{
		return 0;
	}

	var temp = string.Empty;
	char ch = (char)0;

	for (int i = 0; i < input.Length; i++)
	{
		if (input[i] % 2 == 1)
		{
			ch = (char)i;
		}

		var res = input[i] / 2;
		for (int j = 0; j < res; j++)
		{
			temp = temp + (char)i;
		}
	}

	permute(temp.ToCharArray(), 0, ch);

	MaxWord.Dump();
	
	return MaxLength;
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

public void permute(char[] s, int l, char ch)
{
	if (l == s.Length)
	{
		var res = new String(s) + (ch == 0 ? "" : ch.ToString()) + new String(s.Reverse().ToArray());
		if (MaxLength < res.Length)
		{
			MaxLength = res.Length;
			MaxWord = res;
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