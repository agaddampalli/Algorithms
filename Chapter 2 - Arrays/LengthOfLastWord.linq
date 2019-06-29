<Query Kind="Program" />

void Main()
{
	LengthOfLastWord("a 12334").Dump();
}

public int LengthOfLastWord(string s)
{
	if(string.IsNullOrWhiteSpace(s))
	{
		return 0;
	}
	
	int count = 0;
	for (int i = s.Length - 1; i >= 0; i--)
	{
		if(count > 0 && s[i] == 32)
		{
			return count;
		}
		
		if(s[i] != 32)
			count++;
	}
	
	return count;
}
