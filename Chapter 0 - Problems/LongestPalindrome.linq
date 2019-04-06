<Query Kind="Program" />

void Main()
{
	string s = "abbabba";
	longestPalindrome(s).Dump();
	LongestPalindrome(s).Dump();
}

public string longestPalindrome(string s)
{
	if (string.IsNullOrWhiteSpace(s))
	{
		return string.Empty;
	}

	int i = 0, j = 1;
	string longestPalindrome = string.Empty;
	while (i < s.Length)
	{
		while (j <= s.Length)
		{
			var substring = s.Substring(i, j - i);
			if (IsPalindrome(substring) && substring.Length > longestPalindrome.Length)
			{
				longestPalindrome = substring;
			}
			j++;
		}
		i++;
		j = i+1;
	}

	return longestPalindrome;
}

public string LongestPalindrome(string s)
{
	if (string.IsNullOrWhiteSpace(s))
	{
		return string.Empty;
	}

	var booleanArray = new Boolean[s.Length, s.Length];
	var maxLength = 1;
	var startIndex = 0;
	for (int i = 0; i < s.Length; i++)
	{
		booleanArray[i,i] = true;
	}

	for (int i = 0; i < s.Length-1; i++)
	{
		if(s[i] == s[i+1])
		{
			booleanArray[i, i+1] = true;
			maxLength = 2;
			startIndex = i;
		}
	}
	
	for (int k = 3; k < s.Length; k++)
	{
		for(int i = 0; i < s.Length - k + 1 ; i++)
		{
			var j = i+k-1;
			if(booleanArray[i+1,j-1] && s[i] == s[j])
			{
				booleanArray[i, j] = true;
				if(k > maxLength)
				{
					maxLength = k+1;
					startIndex = i;
				}
			}
		}
	}
	
	booleanArray.Dump();
	return s.Substring(startIndex, maxLength);
}

public bool IsPalindrome(string s)
{
	char[] array = s.ToCharArray();
	Array.Reverse(array);
	string backwards = new string(array);

	return s == backwards;
}