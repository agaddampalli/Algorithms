<Query Kind="Program" />

void Main()
{
	WordPattern("abba", "dog dog dog dog").Dump();
}

public bool WordPattern(string pattern, string str)
{
	if (string.IsNullOrEmpty(pattern))
	{
		return string.IsNullOrEmpty(str);
	}

	var words = str.Split(' ');

	if (pattern.Length != words.Length)
	{
		return false;
	}

	var dict = new Dictionary<char, string>();
	var wordsSet = new HashSet<string>();
	for (int i = 0; i < words.Length; i++)
	{
		if (dict.ContainsKey(pattern[i]))
		{
			if (dict[pattern[i]] != words[i])
			{
				return false;
			}
		}
		else
		{
			if(wordsSet.Contains(words[i]))
			{
				return false;
			}
			
			dict.Add(pattern[i], words[i]);
			wordsSet.Add(words[i]);
		}
	}

	return true;
}
