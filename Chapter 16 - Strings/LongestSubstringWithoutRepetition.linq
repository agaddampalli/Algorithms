<Query Kind="Program" />

void Main()
{
	var s = " ";
	
	FindSubStringWithoutRepetition(s).Dump();
}

public string FindSubStringWithoutRepetition(string s)
{
	if(string.IsNullOrEmpty(s))
	{
		return string.Empty;
	}
	
	var charset = new HashSet<char>();
	
	var start = 0;
	var index  = 0;
	var maxLength = 1;
	var startIndex = 0;
	
	while(index < s.Length)
	{
		if(charset.Contains(s[index]))
		{
			charset.Remove(s[start++]);
		}
		else
		{
			charset.Add(s[index]);
			if(maxLength < index - start + 1)
			{
				maxLength = index - start + 1;
				startIndex = start;
			}
			
			index++;
		}
	}
	
	return s.Substring(startIndex, maxLength);
}