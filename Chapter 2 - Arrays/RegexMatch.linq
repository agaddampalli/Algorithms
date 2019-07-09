<Query Kind="Program" />

void Main()
{
	IsMatch("ab", ".*c").Dump();
}

public bool IsMatch(string s, string p)
{
	if(string.IsNullOrWhiteSpace(p))
	{
		return string.IsNullOrWhiteSpace(s);
	}
	
	bool firstMatch = !string.IsNullOrWhiteSpace(s) && !string.IsNullOrWhiteSpace(p) && (s[0] == p[0] || p[0] == '.');
	
	if(p.Length >= 2 && p[1] == '*')
	{
		return (IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p)));
	}
	else
	{
		return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
	}
}


public bool IsMatch1(string s, string p)
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