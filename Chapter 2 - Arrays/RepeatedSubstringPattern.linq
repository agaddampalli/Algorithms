<Query Kind="Program" />

void Main()
{
	RepeatedSubstringPattern("ababa").Dump();
}

public bool RepeatedSubstringPattern(string s)
{
	var input = new int[26];
	
	for (int i = 0; i < s.Length; i++)
	{
		input[s[i]-'a']++;
	}
	
	for (int i = 0; i < input.Length; i++)
	{
		if(input[i] % 2 != 0)
		{
			return false;
		}
	}
	
	return true;
}