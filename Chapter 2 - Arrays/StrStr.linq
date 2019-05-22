<Query Kind="Program" />

void Main()
{
	StrStr("aaab", "ab").Dump();
}

public int StrStr(string haystack, string needle) 
{
	if(string.IsNullOrWhiteSpace(needle))
	{
		return 0;
	}
	
	int i =0, j = i;
	
	while(i<=haystack.Length-needle.Length)
	{
		if(j > needle.Length-1 || i+j > haystack.Length-1)
		{
			break;
		}
		
		if(haystack[i+j] == needle[j])
		{
			j++;
		}
		else
		{
			i++;
			j = 0;
		}
	}
	
	return  j == needle.Length ? i : -1;
}