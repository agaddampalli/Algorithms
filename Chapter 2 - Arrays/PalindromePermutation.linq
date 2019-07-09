<Query Kind="Program" />

void Main()
{
	PalindromePermutation("AaBb//a").Dump();

	PalindromePermutation1("aaa").Dump();
	
	IsPalindrome("0P").Dump();
}

public bool PalindromePermutation1(string input)
{
	var inputChars = new int[256];
	
	for (int i = 0; i < input.Length; i++)
	{
		inputChars[input[i]]++;
	}
	
	bool length1Char = false;
	for (int i = 0; i < inputChars.Length; i++)
	{
		if(inputChars[i] % 2 == 1)
		{
			if(length1Char)
			{
				return false;
			}
			
			length1Char = true;
			continue;
		}
		else if(inputChars[i] == 2 || inputChars[i] == 0)
		{
			continue;
		}
		else
		{
			return false;
		}
	}
	
	return true;
}

public bool PalindromePermutation(string input)
{
	input = input.ToLower();
	var palindromeHashSet = new HashSet<char>();
	
	for (int i = 0; i < input.Length; i++)
	{
		if(input[i] == 32)
		{
			continue;
		}
		
		if(palindromeHashSet.Contains(input[i]))
		{
			palindromeHashSet.Remove(input[i]);
		}
		else
		{
			palindromeHashSet.Add(input[i]);
		}
	}
	
	if(palindromeHashSet.Count == 1 || palindromeHashSet.Count == 0)
	{
		return true;
	}
	else
	{
		return false;
	}
}

public bool IsPalindrome(string input)
{
	input = RemoveSpecialCharacters(input);
	if (string.IsNullOrWhiteSpace(input))
	{
		return true;
	}
	
	var length = input.Length -1;
	for (int i = 0; i < (length/2)+1; i++)
	{
		if(input[i] != input[length-i])
		{
			return false;
		}
	}
	
	return true;
}

public static string RemoveSpecialCharacters(string str)
{
	StringBuilder sb = new StringBuilder();
	foreach (char c in str)
	{
		if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') )
		{
			var lowercaseChar = c;
			if(c < 97 && c > 57)
			{
				lowercaseChar = (char)((int)lowercaseChar + 32);
			}
			sb.Append(lowercaseChar);
		}
	}
	return sb.ToString();
}