<Query Kind="Program" />

void Main()
{
	var array = new int[] {0, 1, 3};

	ShortestPalindromeBruteForce("abac").Dump();
	ShortestPalindromePointers("abcabc").Dump();
	ShortestPalindromeKMP("abcabc").Dump();
}

public string ShortestPalindromeBruteForce(string s) 
{
	var rev = Reverse(s);
	
	for (int i = 0; i < s.Length; i++)
	{
		var s1 = s.Substring(0, s.Length-i);
		var s2 = rev.Substring(i);
		if(s1 == s2)
		{
			return rev.Substring(0, i) + s;
		}
	}
	
	return "";
}

public string ShortestPalindromePointers(string s)
{
	
	int i = 0;
	for (int j = s.Length-1; j >= 0; j--)
	{
		if(s[i] == s[j])
		{
			i++;
		}
	}
	
	if(i == s.Length)
	{
		return s;
	}
	
	var rev = Reverse(s.Substring(i));
	return rev + ShortestPalindromePointers(s.Substring(0,i)) + s.Substring(i);
}

public string ShortestPalindromeKMP(string s)
{
	var rev = Reverse(s);
	
	var kmp = GenerateKMPTable(s + "#" + rev);
	
	var temp = Reverse(s.Substring(kmp[kmp.Length-1]));
	
	return temp + s;
}

public string Reverse(string s)
{
	var input = new StringBuilder(s);
	
	int i = 0, j = s.Length-1;
	
	while(i < j)
	{
		var temp = input[j];
		input[j] = input[i];
		input[i] = temp;
		
		i++;
		j--;
	}
	
	return input.ToString();
}

public int[] GenerateKMPTable(string s)
{
	var kmp = new int[s.Length];
	
	int i = 1;
	int j = 0;
	
	while(i < s.Length)
	{
		if (s[i] == s[j])
		{
			kmp[i] = j+1;
			i++;
			j++;
		}
		else
		{
			if( j == 0)
			{
				i++;
				continue;
			}
			else
			{
				j = kmp[j-1];
			}
		}
	}
	
	return kmp;
}