<Query Kind="Program" />

void Main()
{
	var s = "baaabbabbb";
	
	FindSubStringWithoutRepetition(s, 2).Dump();
}

public string FindSubStringWithoutRepetition(string s, int k)
{
	if(string.IsNullOrEmpty(s))
	{
		return string.Empty;
	}
	
	var charset = new Dictionary<char, int>();
	
	var start = 0;
	var index  = 1;
	var maxLength = 1;
	var startIndex = 0;
	var prev = s[0];
	int count = 1;
	while(index < s.Length)
	{
		if(s[index] == prev && count+1 > k)
		{
			while(start < s.Length && s[start] != prev)
			{
				start++;
			}
			
			start++;
			count--;
		}
		else
		{
			if(prev != s[index])
			{
				prev = s[index];
				count = 0;
			}
			
			count++;
			if (maxLength < index - start + 1)
			{
				maxLength = index - start + 1;
				startIndex = start;
			}
			
			index++;
		}
	}
	
	return s.Substring(startIndex, maxLength);
}