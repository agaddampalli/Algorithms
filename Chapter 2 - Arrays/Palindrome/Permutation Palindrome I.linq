<Query Kind="Program" />

void Main()
{
	CanPermutePalindrome("ababac").Dump();
}

public bool CanPermutePalindrome(string s)
{
	var input = new int[128];
	
	for (int i = 0; i < s.Length; i++)
	{
		input[s[i]]++;
	}
	
	int count = 0;
	for (int i = 0; i < input.Length; i++)
	{
		if(input[i] % 2 == 1)
		{
			count++;
		}
		
		if(count > 1)
		{
			return false;
		}
	}
	
	return true;
}
