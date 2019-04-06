<Query Kind="Program" />

void Main()
{
	var input = "leetcode";
	
	FirstUniqChar(input).Dump();
}

// Define other methods and classes here
public int FirstUniqChar(string s)
{

	if (string.IsNullOrWhiteSpace(s))
	{
		return -1;
	}

	var countArray = new int[256];

	for (int i = 0; i < s.Length; i++)
	{
		(countArray[s[i]])++;
	}

	for (int i = 0; i < s.Length; i++)
	{
		if(countArray[s[i]] == 1)
		{
			return i;
		}
	}
	
	return -1;
}