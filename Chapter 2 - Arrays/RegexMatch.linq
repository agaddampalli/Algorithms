<Query Kind="Program" />

void Main()
{
	IsMatch("aa", "a").Dump();
}

public bool IsMatch(string s, string p)
{
	if(string.IsNullOrWhiteSpace(s))
	{
		return false;
	}
	
	if(p.Equals(".") || p.Equals(".*"))
	{
		return true;
	}

	if (p.StartsWith("*"))
	{
		return false;
	}
	
	int i =0, j =0;
	bool hasMatched = false;
	var matchedStack = new Stack<char>();
	var regexStack = new Stack<char>();
	regexStack.Push(p[j]);
	
	while(regexStack.Count != 0 || i != s.Length)
	{
		if(j < p.Length && p[j] == '*')
		{
			regexStack.Push(p[j]);
		}
		
		if(regexStack.Count != 0 && regexStack.Peek() == s[j])
		{
			regexStack.Pop();
			i++;
			j++;
		}
		
	}

	return matchedStack.Count != 0;
}