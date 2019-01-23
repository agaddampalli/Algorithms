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
	var matchedStack = new Stack<char>();
	
	while(j != p.Length)
	{
		if(p[j] =='*')
		{
			if(matchedStack.Count != 0 && matchedStack.Peek() ==  s[i])
			{
				i++;
				j++;
			}
			else
			{
				j++;
			}
		}
		else if (p[j] == '.' || p[j] == s[i])
		{
			matchedStack.Push(s[i]);
			i++;
			j++;
		}
		else
		{
			j++;
		}
	}

	return matchedStack.Count != 0;
}
