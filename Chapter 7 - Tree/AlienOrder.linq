<Query Kind="Program" />

void Main()
{
	StrStr("mississippi", "ippi").Dump();
}

public int StrStr(string haystack, string needle) 
{
	if(string.IsNullOrWhiteSpace(needle))
	{
		return 0;
	}
	
	var lps = GenerateLPS(needle);
	
	lps.Dump();
	
	int j = 0, i = 0;
	while (i < haystack.Length)
	{
		while(j < needle.Length)
		{
			if(haystack[i] == needle[j])
			{
				j++;
			}
			else
			{
				if(j != 0)
				{
					j = lps[j - 1];
					continue;
				}
			}
			
			if(j == needle.Length)
			{
				return i - j + 1;
			}
			
			i++;
		}
	}
	
	return -1;
}

public int[] GenerateLPS(string input)
{
	var lps = new int[input.Length];
	
	int i = 1;
	int j = 0;
	
	while(i < input.Length)
	{
		if(input[i] == input[j])
		{
			lps[i] = j+1;
			i++;
			j++;
		}
		else
		{
			if(j != 0)
			{
				j = lps[j-1];
				continue;
			}
			
			i++;
		}
	}
	
	return lps;
}