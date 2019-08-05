<Query Kind="Program" />

void Main()
{
	var s = "abaacad";
	
	FindSubStringWithoutRepetition(s).Dump();
}

public string FindSubStringWithoutRepetition(string s)
{
	if(string.IsNullOrEmpty(s))
	{
		return string.Empty;
	}
	
	var charset = new HashSet<char>();
	
	var index  = 0;
	var output = new StringBuilder();
	
	while(index < s.Length)
	{
		if(!charset.Contains(s[index]))
		{
			charset.Add(s[index]);
			output.Append(s[index]);
		}
		
		index++;
	}

	return output.ToString();
}