<Query Kind="Program" />

void Main()
{
	RepeatedSubstringPattern("ababa").Dump();
}

public bool RepeatedSubstringPattern(string s)
{
	var lps = Generate(s);
	
	var maxLength = lps[s.Length-1];
	
	return maxLength> 0 && (s.Length % (s.Length-maxLength))  == 0;
}


public int[] Generate(string pattern)
{
	var patternArray = new int[pattern.Length];

	int i = 1, j = 0;
	bool isMatched = false;
	while (i < pattern.Length)
	{
		if (pattern[i] == pattern[j])
		{
			isMatched = true;
			patternArray[i] = j + 1;
			j++;
		}
		else
		{
			j = j != 0 ? patternArray[j - 1] : j;

			if (isMatched)
			{
				isMatched = !isMatched;
				continue;
			}
		}

		i++;
	}

	return patternArray;
}