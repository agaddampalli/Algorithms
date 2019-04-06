<Query Kind="Program" />

void Main()
{
	var input = new string[] {"baab","bacb","b","cbc"};
	LongestCommonPrefix(input).Dump();
}


public string LongestCommonPrefix(string[] strs)
{
	if (strs == null || strs.Length == 0)
	{
		return string.Empty;
	}
	
	if(strs.Length == 1)
	{
		return strs[0];	
	}
	
	var length = Math.Min(strs[0].Length, strs[1].Length);
	var commonPrefix = "";
	for (int i = 0; i < length; i++)
	{
		if(strs[0][i] != strs[1][i])
		{
			break;
		}
		
		commonPrefix = commonPrefix + strs[0][i];
	}

	if(string.IsNullOrWhiteSpace(commonPrefix))
	{
		return string.Empty;
	}
	
	for (int i = 2; i < strs.Length; i++)
	{
		if (string.IsNullOrWhiteSpace(strs[i]))
		{
			return string.Empty;
		}
		
		int j = 0;
		while (j < commonPrefix.Length && j < strs[i].Length && strs[i][j] == commonPrefix[j])
		{
			j++;
		}
		
		if(j == 0)
		{
			return string.Empty;
		}

		commonPrefix = commonPrefix.Substring(0,j);
	}
	
	return commonPrefix;
}