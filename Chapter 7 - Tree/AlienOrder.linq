<Query Kind="Program" />

void Main()
{
	StrStr("mississippi", "issip").Dump();
}

public int StrStr(string haystack, string needle) 
{
	if(string.IsNullOrWhiteSpace(needle))
	{
		return 0;
	}
	
	int i =0, j = i;
	int index = 0;
	bool isFound = false;
	
	while(i<haystack.Length)
	{
		if(j > needle.Length)
		{
			break;
		}
		
		if(haystack[i] == needle[j])
		{
			if(!isFound)
			{
				index = i;
			}
			isFound = true;
			j++;
			i++;
		}
		else if(isFound)
		{
			i--;
			j = 0;
			isFound = false;
		}
		else
		{
			i++;
		}
	}
	
	return isFound && j == needle.Length ? index : -1;
}