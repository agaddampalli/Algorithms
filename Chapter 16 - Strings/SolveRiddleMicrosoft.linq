<Query Kind="Program" />

void Main()
{
	SolveRiddle("????????").Dump();
	SolveRiddle1("zz?kz?kz?").Dump();
}

public string SolveRiddle1(string s)
{
	var str = new StringBuilder(s);
	var prev = default(char);
	for (int i = 0; i < s.Length; i++)
	{
		if (str[i] == '?')
		{
			if (i + 1 < s.Length)
			{
				str[i] = (char)((prev + str[i+1]) % 26 + 'a');
			}
			else
			{
				str[i] =  (char)(prev % 26 + 'a');
			}
		}

		prev = str[i];
	}

	return str.ToString();
}

public string SolveRiddle(string s)
{
	var str = new StringBuilder(s);
	var prev = default(char);
	for (int i = 0; i < s.Length; i++)
	{
		if(str[i] == '?')
		{
			if(i+1 < s.Length)
			{
				str[i] = GetNextChar(prev, str[i+1]);
			}
			else
			{
				str[i] = GetNextChar(prev);
			}
		}
		
		prev = str[i];
	}
	
	return str.ToString();
}

private static char GetNextChar(char prev)
{
	return GetNextChar(prev, default(char));
}

private static char GetNextChar(char prev, char next)
{
	if(prev == default(char) && next == default(char))
	{
		return 'a';
	}

	if (prev == default(char) && next != default(char))
	{
		for (int i = 0; i < 26; i++)
		{
			var ch = (char) ('a' + i);
			if(ch != next)
			{
				return ch;
			}
		}
	}

	for (int i = 0; i < 26; i++)
	{
		var ch = (char)('a' + i);
		if (ch != next && ch != prev)
		{
			return ch;
		}
	}
	
	return default(char);
}