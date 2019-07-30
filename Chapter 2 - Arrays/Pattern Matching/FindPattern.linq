<Query Kind="Program" />

void Main()
{
	Generate("abcabaabc").Dump();
	Find("abcabaabx", "aa").Dump();
}

public bool Find(string s, string pattern)
{
	var patternArray = Generate(pattern);

	int j = 0;
	int startIndex = 0;
	bool isMatched = false;
	for (int i = 0; i < s.Length; i++)
	{
		if (s[i] == pattern[j])
		{
			if (!isMatched)
			{
				isMatched = true;
				startIndex = i;
			}

			j++;
		}
		else
		{
			if (j != 0)
			{
				j = patternArray[j - 1];
				i--;
			}
			isMatched = false;
		}

		if (j == pattern.Length)
		{
			startIndex.Dump();
			return true;
		}
	}
	return false;
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