<Query Kind="Program" />

void Main()
{
	PalindromePermutation("Tact Coa").Dump();
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
	if(string.IsNullOrWhiteSpace(input))
	{
		return true;
	}
	
	input = RemoveSpecialCharacters(input);
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
		if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
		{
			sb.Append(c);
		}
	}
	return sb.ToString();
}